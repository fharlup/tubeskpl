using System;
using System.Collections.Generic;

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

public enum StatusPemesanan
{
    Available,
    Booking,
    Done
}

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