﻿// <copyright file="ScanInterfaces.cs" company="Hottinger Baldwin Messtechnik GmbH">
//
// SharpScan, a library for scanning and configuring HBM devices.
//
// The MIT License (MIT)
//
// Copyright (C) Hottinger Baldwin Messtechnik GmbH
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
// ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
// </copyright>

namespace Hbm.Devices.Scan
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.NetworkInformation;

    public class ScanInterfaces
    {
        private readonly IList<NetworkInterface> interfaces;

        public ScanInterfaces()
        {
            this.interfaces = new List<NetworkInterface>();
            NetworkInterface[] ifaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in ifaces)
            {
                if (ni.SupportsMulticast &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    (ni.OperationalStatus == OperationalStatus.Up || ni.OperationalStatus == OperationalStatus.Unknown))
                {
                    this.interfaces.Add(ni);
                }
            }
        }

        public IList<NetworkInterface> NetworkInterfaces
        {
            get { return new ReadOnlyCollection<NetworkInterface>(this.interfaces); }
        }
    }
}