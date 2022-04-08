namespace HaighFramework.Audio.OpenAL.OggVorbis;

    /// <summary>
    /// Summary description for Page.
    /// </summary>
    internal class Page	
{
	private static uint[] crc_lookup=new uint[256];
	
	private static uint crc_entry(uint index)
	{
		uint r = index << 24;
		for(int i=0; i<8; i++)
		{
			if((r& 0x80000000)!=0)
			{
				r=(r << 1)^0x04c11db7; /* The same as the ethernet generator
										polynomial, although we use an
										unreflected alg and an init/final
										of 0, not 0xffffffff */
			}
			else
			{
				r <<= 1;
			}
		}
		return (r & 0xffffffff);
	}

	internal byte[] header_base;
	internal int header;
	internal int header_len;
	internal byte[] body_base;
	internal int body;
	internal int body_len;

	internal int version()
	{
		return header_base[header+4]&0xff;
	}
	internal int continued()
	{
		return (header_base[header+5]&0x01);
	}
	internal int bos()
	{
		return (header_base[header+5]&0x02);
	}
	internal int eos()
	{
		return (header_base[header+5]&0x04);
	}
	internal long granulepos()
	{
		long foo = header_base[header+13]&0xff;
		foo = (foo<<8) | (uint)(header_base[header+12]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+11]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+10]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+9]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+8]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+7]&0xff);
		foo = (foo<<8) | (uint)(header_base[header+6]&0xff);
		return(foo);
	}
	internal int serialno()
	{
		return (header_base[header+14]&0xff)|
			((header_base[header+15]&0xff)<<8)|
			((header_base[header+16]&0xff)<<16)|
			((header_base[header+17]&0xff)<<24);
	}
	internal int pageno()
	{
		return (header_base[header+18]&0xff)|
			((header_base[header+19]&0xff)<<8)|
			((header_base[header+20]&0xff)<<16)|
			((header_base[header+21]&0xff)<<24);
	}

	internal void checksum()
	{
		uint crc_reg=0;
		uint a, b;
    
		for(int i=0;i<header_len;i++)
		{
			a = header_base[header+i] & 0xffu;
			b = (crc_reg >> 24) & 0xff;
			crc_reg = (crc_reg<<8)^crc_lookup[a^b];
			//crc_reg = (crc_reg<<8)^(uint)(crc_lookup[((crc_reg >> 24)&0xff)^(header_base[header+i]&0xff)]);
		}
		for(int i=0;i<body_len;i++)
		{
			a = body_base[body+i] & 0xffu;
			b = (crc_reg >> 24) & 0xff;
			crc_reg = (crc_reg<<8)^crc_lookup[a^b];

			//crc_reg = (crc_reg<<8)^(uint)(crc_lookup[((crc_reg >> 24)&0xff)^(body_base[body+i]&0xff)]);
		}
		header_base[header+22]=(byte)crc_reg/*&0xff*/;
		header_base[header+23]=(byte)(crc_reg>>8)/*&0xff*/;
		header_base[header+24]=(byte)(crc_reg>>16)/*&0xff*/;
		header_base[header+25]=(byte)(crc_reg>>24)/*&0xff*/;
	}

	internal Page()
	{
		for(uint i=0; i<crc_lookup.Length; i++)
		{
			crc_lookup[i]=crc_entry(i);
		}	
	}
}
