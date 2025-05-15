class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Selamat Datang di Bank Pelita");
        List<Bank> daftarAkun = new List<Bank>
        {
            new Bank("24241010", "Ngabfin", "3039", 100000000),
            new Bank("23241010", "Cacicu", "5643", 2000)
        };
        Console.Write("Masukkan Nomor Rekening: ");
        string norek = Console.ReadLine();
        Console.Write("Masukkan Password: ");
        string password = Console.ReadLine();

        Bank akunLogin = daftarAkun.Find(akun => akun.NomorRekening == norek);
        if (akunLogin == null)
        {
            Console.WriteLine("Nomor rekening tidak ditemukan.");
            return;
        }
        else if (akunLogin.Password != password)
        {
            Console.WriteLine("Password salah.");
            return;
        }
        Console.WriteLine($"\nLogin berhasil. Selamat datang, {akunLogin.Nama}!");
        Console.ReadKey();
        Console.Clear();


        while (true)
        {
            Console.WriteLine("\n Selamat Datang di Bamk Pelita");
            Console.WriteLine("\n Silahkan Pilih Menu di Bawah:");
            Console.WriteLine("1. Cek Saldo");
            Console.WriteLine("2. Tarik Tunai");
            Console.WriteLine("3. Setor Tunai");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu: ");
            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    akunLogin.TampilkanInfo();
                    Console.WriteLine("Tekan sembarang tombol untuk kembali");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    
                case 2:
                    Console.Write("Masukkan Jumlah yang Ingin di Tarik: ");
                    if (double.TryParse(Console.ReadLine(), out double jumlahtarik))
                    {
                        akunLogin.TarikTunai(jumlahtarik);
                    }
                    Console.WriteLine("Tekan sembarang tombol untuk kembali");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Write("Masukkan Jumlah yang Ingin di Setor: ");
                    if (double.TryParse(Console.ReadLine(), out double jumlahsetor))
                    {
                        akunLogin.SetorTunai(jumlahsetor);
                    }
                    Console.WriteLine("Tekan sembarang tombol untuk kembali");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                   
                case 4:
                    Console.Write("Masukkan Nomor Rekening Tujuan: ");
                    string norekTujuan = Console.ReadLine();
                    Bank akunTujuan = daftarAkun.Find(akun => akun.NomorRekening == norekTujuan);
                    if (akunTujuan == null)
                    {
                        Console.WriteLine("Nomor rekening tujuan tidak ditemukan.");
                        break;
                    }
                    Console.Write("Masukkan Jumlah yang Ingin di Transfer: ");
                    if (double.TryParse(Console.ReadLine(), out double jumlahtransfer))
                    {
                        akunLogin.TransferTunai(akunTujuan, jumlahtransfer);
                    }
                    Console.WriteLine("Tekan sembarang tombol untuk kembali");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("Terima Kasih Telah Menggunakan Jasa dan Layanan Kami");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    break;
            }
        }
    }
}

class Bank
{
    public string NomorRekening { get; set; }
    public string Nama { get; set; }
    public string Password { get; set; }
    public double Saldo { get; set; }
    public Bank(string norek, string nama, string password, double saldo)
    {
        NomorRekening = norek;
        Nama = nama;
        Password = password;
        Saldo = saldo;
    }
    public void TampilkanInfo()
    {
        Console.WriteLine($"Nomor Rekening: {NomorRekening}");
        Console.WriteLine($"Nama: {Nama}");
        Console.WriteLine($"Saldo: {Saldo}");
    }
    public void TarikTunai(double jumlah)
    {
        if (jumlah > Saldo)
        {
            Console.WriteLine("Saldo tidak mencukupi");
        }
        else if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah tidak valid");
        }
        else
        {
            Saldo -= jumlah;
            Console.WriteLine($"Tarik Tunai Berhasil. Saldo Anda Sekarang: {Saldo}");
        }
    }
    public void SetorTunai(double jumlah)
    {
        if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah setor tidak valid");
        }
        else
        {
            Saldo += jumlah;
            Console.WriteLine($"Setor Tunai Berhasil. Saldo Anda Sekarang: {Saldo}");
        }
    }
    public void TransferTunai(Bank tujuan, double jumlah)
    {
        if (jumlah > Saldo)
        {
            Console.WriteLine("Saldo tidak mencukupi");
        }
        else if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah tidak valid");
        }
        else
        {
            Saldo -= jumlah;
            tujuan.Saldo += jumlah;
            Console.WriteLine($"Transfer Berhasil. Saldo Anda Sekarang: {Saldo}");
        }
    }
}
