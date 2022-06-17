using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AydoganMotors.DL
{
    
        public static class DataLayer
        {
            static MySqlConnection conn = new MySqlConnection(
                new MySqlConnectionStringBuilder()
                {
                    Server = "localhost",
                    Database = "aydogan_motors",
                    UserID = "root",
                    Password = "",

                }.ConnectionString
             );

            public static int MüşteriEkle(Musteri m)
            {

                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_MusteriEkle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", m.ID);
                    komut.Parameters.AddWithValue("@ad", m.Ad);
                    komut.Parameters.AddWithValue("@soy", m.Soyad);
                    komut.Parameters.AddWithValue("@tel", m.Telefon);
                    komut.Parameters.AddWithValue("@mail", m.Mail);
                    komut.Parameters.AddWithValue("@adr", m.Adres);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }

            }

            internal static int MüşteriSil(string id)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_MusteriSil", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", id);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }


            internal static int MüşteriGüncelle(Musteri m)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_MusteriGuncelle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", m.ID);
                    komut.Parameters.AddWithValue("@ad", m.Ad);
                    komut.Parameters.AddWithValue("@soy", m.Soyad);
                    komut.Parameters.AddWithValue("@tel", m.Telefon);
                    komut.Parameters.AddWithValue("@mail", m.Mail);
                    komut.Parameters.AddWithValue("@adr", m.Adres);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }




            internal static int AracSil(string id)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_AracSil", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", id);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static int SatisSil(string id)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_SatisSil", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", id);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }


            internal static int AracGüncelle(Arac u)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_AracKmGuncelle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", u.ID);
                    komut.Parameters.AddWithValue("@ad", u.Ad);
                    komut.Parameters.AddWithValue("@kategori", u.Kategori);
                    komut.Parameters.AddWithValue("@fiyat", u.Fiyat);
                    komut.Parameters.AddWithValue("@kilometre", u.Kilometre);
                    komut.Parameters.AddWithValue("@kasatipi", u.KasaTipi);
                    komut.Parameters.AddWithValue("@detay", u.Detay);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }


            internal static DataSet MüşteriGetir(string filtre)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut;
                    if (string.IsNullOrEmpty(filtre))
                    {
                        komut = new MySqlCommand("Aydogan_MusterilerHepsi", conn);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        komut = new MySqlCommand("Aydogan_MusteriBul", conn);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                        komut.Parameters.AddWithValue("@filtre", filtre);
                    }

                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                    adp.Fill(dataSet);

                    return dataSet;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }
            internal static int AracEkle(Arac u)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_AracEkle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@id", u.ID);
                    komut.Parameters.AddWithValue("@ad", u.Ad);
                    komut.Parameters.AddWithValue("@kategori", u.Kategori);
                    komut.Parameters.AddWithValue("@fiyat", u.Fiyat);
                    komut.Parameters.AddWithValue("@kilometre", u.Kilometre);
                    komut.Parameters.AddWithValue("@kasatipi", u.KasaTipi);
                    komut.Parameters.AddWithValue("@detay", u.Detay);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }
            internal static DataSet AracGetir(string filtre)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut;
                    if (string.IsNullOrEmpty(filtre))
                    {
                        komut = new MySqlCommand("Aydogan_AraclarHepsi", conn);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        komut = new MySqlCommand("Aydogan_AracBul", conn);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                        komut.Parameters.AddWithValue("@filtre", filtre);
                    }

                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                    adp.Fill(dataSet);

                    return dataSet;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static int SatisEkle(Satis s)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_SatisEkle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@sid", s.ID);
                    komut.Parameters.AddWithValue("@mid", s.MusteriID);
                    komut.Parameters.AddWithValue("@aid", s.AracID);
                    komut.Parameters.AddWithValue("@tarih", s.Tarih);
                    komut.Parameters.AddWithValue("@fiyat", s.Fiyat);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }

            }

            internal static int OdemeEkle(Odeme o)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_OdemeEkle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@oid", o.ID);
                    komut.Parameters.AddWithValue("@mid", o.MusteriID);
                    komut.Parameters.AddWithValue("@tarih", o.Tarih);
                    komut.Parameters.AddWithValue("@tutar", o.Tutar);
                    komut.Parameters.AddWithValue("@tur", o.Tur);
                    komut.Parameters.AddWithValue("@aciklama", o.Aciklama);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }
            internal static int OdemeGüncelle(Odeme o)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_OdemeGuncelle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@oid", o.ID);
                    komut.Parameters.AddWithValue("@mid", o.MusteriID);
                    komut.Parameters.AddWithValue("@tarih", o.Tarih);
                    komut.Parameters.AddWithValue("@tutar", o.Tutar);
                    komut.Parameters.AddWithValue("@tur", o.Tur);
                    komut.Parameters.AddWithValue("@aciklama", o.Aciklama);

                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static int SatisGüncelle(Satis s)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_SatisGuncelle", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@sid", s.ID);
                    komut.Parameters.AddWithValue("@mid", s.MusteriID);
                    komut.Parameters.AddWithValue("@aid", s.AracID);
                    komut.Parameters.AddWithValue("@tarih", s.Tarih);
                    komut.Parameters.AddWithValue("@fiyat", s.Fiyat);


                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static DataSet SatisDeyat()
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_SatisDetay", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;


                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                    adp.Fill(dataSet);

                    return dataSet;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static DataSet OdemeDetay()
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_OdemeDetay", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;


                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                    adp.Fill(dataSet);

                    return dataSet;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }

            internal static int OdemeSil(string id)
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    MySqlCommand komut = new MySqlCommand("Aydogan_OdemeSil", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@oid", id);


                    int res = komut.ExecuteNonQuery();
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                }
            }


        }
    }

