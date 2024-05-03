using System;

public enum Role
{
    Murid,
    Guru
}

public enum MataPelajaran
{
    Matematika,
    Fisika,
    Kimia,
    Biologi,
    BahasaIndonesia,
    BahasaInggris,
    Sains,
    IPA,
    IPS
}

// State Murid
public enum StatusPemesanan
{
    Pending,
    Ongoing,
    Done
}

// State Guru
public enum PengerjaanState
{
    bersedia,
    SudahDipesan,
    Mengajar
};

public enum Trigger
{
    Pesan,
    cancel,
    mengajar,
    selesai
};

public class User
{
    public Role Role { get; set; }
    public string Name { get; set; }
    public List<MataPelajaran> MataPelajaran { get; set; }
}

public class Pemesanan
{
    public User Guru { get; set; }
    public User Murid { get; set; }
    public MataPelajaran MataPelajaran { get; set; }
    public StatusPemesanan Status { get; set; }
}
