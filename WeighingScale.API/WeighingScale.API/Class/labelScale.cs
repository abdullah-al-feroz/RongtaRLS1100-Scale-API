using System.Runtime.InteropServices;

namespace WeighingScale.API.Class
{
    public class labelScale
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void SaleDataCallback(string sResult, int iRecNo, int aCount);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int rtscaleConnect(string addr, int baudRate, ref int connid);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int rtscaleDisConnect(int connid);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int rtscaleGetPluWeight(int connid, ref double dWeight);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadSaleData")]
        public static extern int rtscaleUploadSaleData(int connid, bool AIsClearData, SaleDataCallback callback);
    }
}
