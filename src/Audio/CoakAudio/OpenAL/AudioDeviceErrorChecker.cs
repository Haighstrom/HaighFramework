﻿using System;
using System.Collections.Generic;


namespace HaighFramework.Audio.OpenAL
{
    struct AudioDeviceErrorChecker : IDisposable
    {
        #region Fields

        readonly IntPtr Device;
        static readonly string ErrorString = "Device {0} reported {1}.";

        #endregion

        #region Constructors

        public AudioDeviceErrorChecker(IntPtr device)
        {
            if (device == IntPtr.Zero)
                throw new HException("Audio Device Error");

            Device = device;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            AlcError err = Alc.GetError(Device);
            switch (err)
            {
                case AlcError.OutOfMemory:
                    throw new OutOfMemoryException(String.Format(ErrorString, Device, err));

                case AlcError.InvalidValue:
                    throw new HException(ErrorString, Device, err);

                case AlcError.InvalidDevice:
                    throw new HException(ErrorString, Device, err);

                case AlcError.InvalidContext:
                    throw new HException(ErrorString, Device, err);

                case AlcError.NoError:
                default:
                    // everything went fine, do nothing
                    break;
            }
        }

        #endregion
    }
}