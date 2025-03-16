namespace QRCreator
{
    public class ApiRequest
    {
        public long accountNo { get; set; }
        public string? accountName { get; set; }
        public int acqId { get; set; }
        // Test: Coding 1
        // Main: Coding 4
        public int amount { get; set; }
        public string? addInfo { get; set; }
        public string? format { get; set; }
        // Main: Coding 3
        public string? template { get; set; }
    }

    public class Data
    {
        public int acpId { get; set; }
        public string? accountName { get; set; }
        // Main: Coding 5
        public string? qrCode { get; set; }
        public string? qrDataURL { get; set; }
        // Main: Coding
    }

    public class ApiResponse
    {
        public string? code { get; set; }
        // Main: Coding 6
        public string? desc { get; set; }
        public Data? data { get; set; }
        // Main: Coding 2

    }
}
