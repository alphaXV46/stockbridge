
LAPORAN TUGAS AKHIR PBO DATABASE DAN PPL MEMBUAT APLIKASI MANAJEMEN LOGISTIK (STOCKBRIDGE) BERBASIS DESKTOP MENGGUNAKAN C# DENGAN DATABASE SQL SERVER 


 



    Disusun Oleh:
1.	Asa Enggal Daviyana (1024012313)
2.	Geraldy Febriansyah (1024012318)
3.	Indira (1023012320)



KOMPETENSI KEAHLIAN REKAYASA PERANGKAT LUNAK KONSENTRASI PENGEMBANGAN PERANGKAT LUNAK DAN GIM  
SMK NEGERI 1 CIBINONG
TAHUN 2026
LEMBAR PENGESAHAN PEMBIMBING
GURU MATA PELAJARAN


Telah Disahkan dan Disetujui Laporan Tugas Akhir Mapel RPL yang Berjudul :
“Membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server”
 
 
 
Yang disusun oleh:
1.	Asa Enggal Daviyana (1024012313)
2.	Geraldy Febriansyah (1024012318)
3.	Indira (1023012320)


Telah Disahkan dan Disetujui
Pada Hari ………., Tanggal ………., Bulan ………., Tahun 2026
Oleh:


        Pembimbing,		              Pembimbing,		                 Pembimbing,



Arief Yunianto, S.Kom	      Fani Indriyani, S.Kom	     Alfi RahmanHakim, S.Kom
 198406232022211017	       199707242025212114	         198302062023211007


IDENTITAS SISWA/I PESERTA

 
Nama Siswa			: Asa Enggal Daviyana
Nomor Induk Siswa		: 1024012313
Program Keahlian		: Rekayasa Perangkat Lunak
Tempat Tanggal Lahir		: Bogor, 17 Januari 2009
Kelas				: XI RPL 1
Jenis Kelamin			: Laki-laki
Alamat	: Perumahan Griya Puspa Asri, Jalan Ksr Dadi Kusmayadi Blok C1 No.13, RT.7/RW.7, Kel. Tengah, Cibinong
No Handphone		: 0812-8213-5697
Nama Pembimbing		: Arief Yunianto, S.Kom
				
				Cibinong, 5 Mei 2026
				Tertanda,

				Asa Enggal Daviyana




IDENTITAS SISWA/I PESERTA

 
Nama Siswa			: Geraldy Febriansyah
Nomor Induk Siswa		: 1024012318
Program Keahlian		: Rekayasa Perangkat Lunak
Tempat Tanggal Lahir		: Jakarta, 19 februari 2009
Kelas				: XI RPL 1
Jenis Kelamin			: Laki-laki
Alamat	: Jl. Perum Gaferi 2 Blok BK No.19, RT 4/RW 15 Sukahati, Kec. Cibinong, Kabupaten Bogor, Jawa Barat 16913
No Handphone		: 0818-0847-0500
Nama Pembimbing		: Arief Yunianto, S.Kom
				
				Cibinong, 5 Mei 2026
				Tertanda,

				Geraldy Febriansyah






IDENTITAS SISWA/I PESERTA

 
Nama Siswa			: Indira
Nomor Induk Siswa		: 1024012320
Program Keahlian		: Rekayasa Perangkat Lunak
Tempat Tanggal Lahir		: Bogor, 02 Juli 2008
Kelas				: XI RPL 1
Jenis Kelamin			: Perempuan
Alamat	: Kp. Pondok Manggis rt 02 rw 02, No. 117, Bojongbaru, Bojonggede, Kabupaten Bogor, Jawa Barat
No Handphone		: 0882-1019-8853
Nama Pembimbing		: Arief Yunianto, S.Kom
				
				Cibinong, 5 Mei 2026
				Tertanda,

				Indira




KATA PENGANTAR

Puji syukur kehadirat Tuhan Yang Maha Esa atas segala rahmat dan karunia-Nya, sehingga penyusun dapat menyelesaikan laporan tugas akhir/proyek dengan judul "Pengembangan Aplikasi Manajemen Logistik 'StockBridge' Berbasis Desktop Menggunakan C# dan Database SQL Server" dengan baik dan tepat pada waktunya. 
Laporan ini disusun berdasarkan hasil riset, observasi, serta praktik mandiri dalam proses perancangan sistem distribusi dan inventaris barang. Aplikasi StockBridge dirancang menggunakan pendekatan Pemrograman Berorientasi Objek (OOP) dengan bahasa C# untuk memastikan sistem yang tangguh, serta integrasi database SQL Server untuk pengelolaan data stok yang aman dan terpusat. Fokus utama aplikasi ini adalah untuk mengoptimalkan efisiensi manajemen logistik, meminimalisir kesalahan input manual, serta mempercepat proses pemantauan arus barang secara real-time. 
Penyusun menyadari sepenuhnya bahwa laporan ini masih jauh dari kesempurnaan, baik dari segi materi maupun teknik penyajiannya. Oleh karena itu, kritik dan saran yang membangun dari pembaca sangat diharapkan demi perbaikan dan pengembangan aplikasi serta laporan ini di masa yang akan datang. 
Akhir kata, penyusun mengucapkan terima kasih yang sebesar-besarnya kepada semua pihak yang telah memberikan dukungan, bimbingan, dan bantuan selama proses penyusunan laporan serta pembuatan aplikasi ini.


Cibinong, ............... 2026 


Penulis


DAFTAR ISI

LEMBAR PENGESAHAN PEMBIMBING GURU MATA PELAJARAN	2
IDENTITAS SISWA/I PESERTA	3
IDENTITAS SISWA/I PESERTA	4
IDENTITAS SISWA/I PESERTA	5
KATA PENGANTAR	6
DAFTAR ISI	7
BAB I PENDAHULUAN	9
A.	Latar Belakang	9
B.	Tujuan	9
C.	Manfaat	10
1.	Manfaat pembuatan Aplikasi	10
2.	Manfaat dari Aplikasi	10
D.	Ruang Lingkup	10
1.	Platform	10
2.	Manajemen Pengguna	10
3.	Manajemen Data	10
4.	Fitur QR  Code	10
5.	Database	11
E.	Jenis Pekerjaan	11
BAB II	13
A.	Landasan Teori	13
1.	Desktop	13
2.	C#	13
3.	SQL Server	13
B.	Peralatan yang Digunakan	13
1.	Perangkat Keras:	14
2.	Perangkat Lunak:	14
C.	Proses pengerjaan membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server	15
1.	Use Case	15
2.	Flowchart	16
3.	Activity Diagram	16
4.	Class Diagram	17
5.	DFD	17
6.	Entity Relation Diagram	17
7.	Perancangan Database	18
8.	User Interface	18
1.	Rancangan Form Login:	18
a)	Layout	18
b)	Kontrol Konten	18
2.	Rancangan Form Menu Utama (Dashboard):	18
a)	Layout	18
b)	Kontrol Konten	18
3.	Rancangan Form Input Produk (Add Product):	18
a)	Layout	18
b)	Kontrol Konten	19
4.	Rancangan Form Scan QR Code (Connect Mobile):	19
a)	Layout:	19
b)	Kontrol Konten	19
9.	Rencana Kerja dan Limasa	19
10.	Langkah – Langkah Pemrograman	19
D.	Hasil yang Dicapai	20
1.	Indikator Keberhasilan	21
2.	Tampilan Akhir Program	21
E.	Manual Book	21
BAB III	21
A.	Kesimpulan	21
B.	Saran	22

BAB I
PENDAHULUAN
A.	Latar Belakang
Di era digitalisasi saat ini, efisiensi dalam pengelolaan rantai pasok (supply chain) menjadi kunci keberhasilan operasional sebuah unit usaha. Namun, banyak pelaku usaha menengah ke bawah yang masih mengandalkan pencatatan manual atau penggunaan spreadsheet sederhana yang memiliki risiko tinggi terhadap kesalahan manusia (human error), kehilangan data, serta kurangnya sinkronisasi antara bagian gudang dan distribusi. 
Permasalahan utama muncul ketika data stok tidak terpantau secara real-time dan tidak adanya batasan hak akses yang jelas antara pengelola (admin) dan staf operasional. Selain itu, proses identifikasi barang yang masih dilakukan secara manual memperlambat arus keluar-masuk barang. Oleh karena itu, diperlukan sebuah solusi perangkat lunak berbasis desktop yang mampu mengintegrasikan manajemen data stok, logistik, dan keamanan data dalam satu sistem yang terpadu dan mudah dioperasikan.

B.	Tujuan
Projek ini bertujuan utuk:
1.	Membangun aplikasi Windows Desktop yang mampu mengelola data rantai pasok secara sistematis menggunakan Bahasa pemrograman C#.
2.	Mengimplementasikan Role-Based Access Control (RBAC) untuk memastikan keamanan data sesuai dengan kewenangan pengguna (Admin dan Staff).
3.	Menerapkan sistem sinkronisasi otomatis antar tabel database (User, Produk, dan Log Transaksi) untuk menjamin integrasi data.
4.	Mengintegrasikan teknologi QR Code untuk mempercepat proses identifikasi dan pembaruan stok barang.

C.	Manfaat
1.	Manfaat pembuatan Aplikasi
Proses pengerjaan ini mengasah logika C# dan manajemen database kami melalui  kerja tim yang profesional. Selain meningkatkan skill teknis, proyek ini menjadi portofolio nyata yang membuktikan bahwa solusi digital berkualitas dapat dibangun secara efektif dengan biaya yang sangat minim.
2.	Manfaat dari Aplikasi
Aplikasi ini meningkatkan akurasi data stok dengan menghilangkan kesalahan manualserta mempercepat operasional gudang melalui fitur scan QR Code. Sistem ini juga menjamin keamanan data lewat pembatasan hak akses pengguna dan menyediakan laporan otomatis yang transparan untuk mempermludah pengambilan keputusan.
D.	Ruang Lingkup
1.	Platform
Aplikasi berjalan secara eksklusif pada sistem operasi Windows (Desktop) yang dibangun dengan .NET Framework.
2.	Manajemen Pengguna
Terdiri dari tiga peran utama, yaitu Admin (akses penuh), Manager (akses gudang penuh), dan  Staff (akses operasional terbatas).
3.	Manajemen Data
 Berfokus pada 3 tabel relasional utama: tabel identitas pengguna, table invetaris barang, dan table riwayat transaksi (log).
4.	Fitur QR  Code
Aplikasi mampu menghasilkan (generate) QR Code untuk setiap barang dan menerima input data melalui pemindaian kode tersebut.
5.	Database
Menggunakan SQL Server Sebagai Pusat data relasional.
E.	Jenis Pekerjaan
Jenis pekerjaan dalam pelaksanaan proyek pembuatan aplikasi Manajemen Logistik (StockBridge) ini meliput:
1.	Perancangan Sistem
Membuat use case diagram, flowchart, activity diagram, dan entity relationship diagram (ERD) untuk menggambarkan alur kerja sistem logistik barang masuk dan keluar.



2.	Perancangan Database
Merancang struktur tabel utama (seperti tabel Users, Category, Products, Request, dan StockLogs), menentukan tipe data, primary key, foreign key, serta relasi antar tabel menggunakan Microsoft SQL Server.
3.	Perancangan Antarmuka Pengguna (UI/XAML)
Merancang tampilan antarmuka pengguna berbasis grafis menggunakan bahasa markup XAML (Extensible Application Markup Language) untuk menghasilkan layout yang modern dan fleksibel. Desain ini meliputi pembuatan tampilan login, dashboard multi-role (Admin, Manager, Staff), form manajemen barang, komponen scan QR Code, serta visualisasi riwayat log transaksi stok.
4.	Pembuatan Logika Program (Code-Behind)
Menulis logika program (backend) menggunakan bahasa C# di Microsoft Visual Studio untuk mendukung file desain XAML, serta menghubungkan aplikasi dengan database SQL Server menggunakan library Dapper.
5.	Implementasi Fitur dan Data Binding
Mengimplementasikan fitur-fitur utama menggunakan mekanisme Data Binding khas WPF untuk sinkronisasi data yang efisien, integrasi fitur pembuatan (generate) dan pemindaian (scan) QR Code barang, manajemen transaksi stok, serta pencatatan otomatis riwayat aktivitas (audit trail).
6.	Pengujian Sistem (Testing)
Melakukan uji coba fungsionalitas (black-box testing) pada setiap jendela dan komponen aplikasi WPF untuk memastikan sistem berjalan dengan baik dan bebas dari kesalahan.
7.	Perbaikan dan Penyempurnaan
Memperbaiki kesalahan teknis, kendala responsivitas tata letak layout XAML, atau kendala koneksi database yang ditemukan selama tahap pengujian agar performa aplikasi lebih optimal.
8.	Penyusunan Laporan dan Manual Book
Menyusun dokumentasi tertulis berupa laporan tugas akhir proyek serta buku panduan praktis penggunaan aplikasi StockBridge.
Adapun pembagian jenis pekerjaan dan peran masing-masing anggota dalam tim adalah sebagai berikut:
1.	Dokumentasi: Asa Enggal Daviyana
2.	Backend Developer: Geraldy Febriansyah
3.	Frontend Developer: Indira


















BAB II
A.	Landasan Teori
1.	Desktop
Desktop adalah tampilan layar utama dari sebuah PC atau media digital lainnya. Selain itu, beberapa orang percaya bahwa desktop adalah layar utama perangkat PC, menawarkan berbagai ikon aplikasi untuk mempermudah pekerjaan pengguna. Desktop ini biasanya muncul setelah Windows dijalankan. Dengan tampilan seperti ini, tidak heran jika kebanyakan orang menganggap desktop mereka sebagai screen wall atau wallpaper. Seperti diketahui, desktop bisa diganti dengan berbagai wallpaper. Selain fitur-fitur tersebut, Desktop juga sangat berguna untuk menyimpan semua ikon di komputer Anda, seperti aplikasi dan data lainnya. Bahkan, di bagian bawah layar adalah tugas atau kotak pencarian dengan default sistem.
2.	C#
Bahasa pemrograman C# atau bisa dibaca C Sharp adalah bahasa pemrograman berorientasi objek dari Microsoft yang memungkinkan developer untuk membangun aplikasi yang berjalan di .NET Framework. Framework inilah yang nantinya akan digunakan untuk mengcompile dan menjalankan kode C#. 
3.	SQL Server
Microsoft SQL Server adalah sistem manajemen basis data relasional (RDBMS) yang dikembangkan oleh Microsoft. Sebagai aplikasi database server, SQL Server merupakan produk perangkat lunak yang bersifat client/server. Alasannya karena memiliki komponen client yang berfungsi menampilkan dan memanipulasi data, serta komponen server yang berfungsi menyimpan, memanggil, dan mengamankan database. 
B.	Peralatan yang Digunakan
Peralatan yang Digunakan untuk membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server, yaitu:
1.	Perangkat Keras:
a)	Laptop/PC:
1)	Prosesor: Minimal Intel Core i3 (Generasi 8 ke atas) atau AMD Ryzen 3.
2)	RAM: Minimal 8 GB (Sangat disarankan karena Visual Studio dan SQL Server cukup memakan memori).
3)	Penyimpanan: SSD sangat disarankan (minimal sisa ruang 20 GB) agar proses buka-tutup aplikasi cepat.
b)	Mouse: Untuk memudahkan desain antarmuka (UI) di Windows Forms.
c)	Smartphone: Digunakan sebagai alat pemindai (scanner) QR Code/Barcode untuk simulasi integrasi perangkat mobile.
d)	Koneksi Internet: Untuk mengunduh library (NuGet Packages) dan koordinasi tim via GitHub.
e)	Printer (Opsional): Jika ingin menguji hasil cetak label QR Code secara fisik.

2.	Perangkat Lunak:
a)	Sistem Operasi: Windows 10 atau Windows 11 (Karena aplikasi berbasis .NET Framework/WPF).
b)	IDE (Integrated Development Environment): Visual Studio 2019 atau 2022 (Pilih beban kerja/workload: .NET Desktop Development).
c)	Database System:
1)	SQL Server Express: Sebagai mesin database utama (gratis).
2)	SQL Server Management Studio (SSMS): Untuk mengelola tabel, relasi, dan memantau data secara visual.
a)	Library & Framework:
1)	.NET Framework 4.7.2 atau lebih baru.
2)	Dapper: Micro-ORM untuk mempermudah akses data ke SQL Server.
3)	ZXing.Net: Library untuk men-generate dan membaca Barcode/QR Code.
C.	Proses pengerjaan membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server
1.	Use Case
 

2.	Flowchart
 
3.	Activity Diagram

4.	Class Diagram
 
5.	DFD

6.	Entity Relation Diagram
 
7.	Perancangan Database
Perancangan database dilakukan untuk menentukan tabel, field, tipe data, primary key, foreign key, dan relasi antar tabel. Database yang digunakan dalam aplikasi StockBridge adalah SQL Server. Berdasarkan struktur database dan Entity Relationship Diagram (ERD) yang digunakan, aplikasi StockBridge memiliki beberapa tabel utama untuk menyimpan data, yaitu tabel Users, Category, Products, Request, dan StockLogs.
8.	User Interface
1.	Rancangan Form Login:
a)	Layout: Menggunakan skema centered card login layout. Terdapat sebuah wadah panel kotak putih di tengah layar dengan sudut membulat (corner radius), memberikan bayangan halus (drop shadow) di atas latar belakang abu-abu terang.
b)	Kontrol Konten: Di bagian atas diisi logo inisial "SB" berwarna biru, nama aplikasi "STOCKBRIDGE", dan sub-label "Supplier Management System". Di bagian input, terdapat isian teks "Username" (TextBox biasa) dan "Password" (WPF PasswordBox dengan ikon mata di ujung kanan untuk mengintip isian teks). Di bagian bawah terdapat tombol utama "SIGN IN" berwarna gelap, diikuti tombol sekunder merah "KELUAR APLIKASI".
2.	Rancangan Form Menu Utama (Dashboard):
a)	Layout: Menggunakan tata letak panel ganda (split-pane dashboard). Sisi kiri selebar 250px adalah kolom statis sidebar navigasi berwarna biru gelap/gelap, sedangkan sisi kanan yang lebih luas adalah area dinamis (`WPF Frame`) untuk memuat halaman.
b)	Kontrol Konten: Di bagian atas sidebar terdapat inisial pengguna aktif dan peran hak aksesnya (misal: "Welcome, Admin"). Di bagian tengah menu navigasi berupa tombol teks (Inventory, Request, Logs, Connect Mobile, Users) yang visibilitasnya akan disembunyikan otomatis oleh sistem berdasarkan hak akses yang login. Bagian kanan atas berisi tombol mini kontrol window (Minimize, Maximize, Close).
3.	Rancangan Form Input Produk (Add Product):
a)	Layout: Jendela modal pop-up berukuran medium yang muncul tepat di tengah layar pemilik aplikasi (*Center Owner*), dihiasi efek bayangan gelap tipis di tepian luar jendela.

b)	Kontrol Konten: Judul utama "TAMBAH PRODUK BARU" diletakkan di pojok kiri atas. Di area formulir, isian dibagi menjadi dua kolom. Kolom kiri memuat input Kode Barang, Nama Produk, dan Harga Beli (dalam Rupiah). Kolom kanan memuat ComboBox pilihan Kategori Barang dan TextBox untuk jumlah Stok Awal. Di bagian bawah terdapat input area deskripsi barang, area konversi satuan (memilih satuan eceran unit pcs, satuan kemasan dus, dan rate konversinya), serta tombol aksi "BATAL" dan "SIMPAN".

4.	Rancangan Form Scan QR Code (Connect Mobile):
a)	Layout: Kotak dialog modal berdimensi kecil di tengah layar, didominasi warna putih bersih dengan aksen biru muda.
b)	Kontrol Konten: Menampilkan judul "Hubungkan Handphone". Area tengah diisi secara penuh oleh gambar QR Code yang dihasilkan secara lokal (offline) berisi alamat IP lokal komputer tempat aplikasi berjalan (contoh: `http://192.168.1.15:8080/`). Di bawah QR Code terdapat teks informasi alamat server aktif untuk input alternatif, serta tombol "TUTUP" di sisi kanan bawah.
9.	Rencana Kerja dan Limasa

10.	Langkah – Langkah Pemrograman
Langkah-langkah pemrograman dalam pembuatan aplikasi StockBridge adalah sebagai berikut:
1.	Membuat proyek baru di Visual Studio berbasis WPF Application (.NET Framework 4.8) dengan format SDK-style “.csproj” agar dependensi pustaka dikelola dengan rapi melalui NuGet.
2.	Menginstal micro-ORM Dapper (versi 2.1.72) melalui Package Manager Console dengan perintah:
      ```powershell
      Install-Package Dapper
      ```
Dan Menginstal pustaka QR/Barcode generator ZXing.Net (versi 0.16.11) untuk membuat gambar barcode lokal tanpa internet:
      ```powershell
      Install-Package ZXing.Net
      ```
3.	Mengonfigurasi file “App.config” untuk mendaftarkan string koneksi menuju basis data SQL Server lokal (`localhost` dengan Windows Authentication).
4.	Membuat logika untuk mendeteksi keberadaan basis data “StockBridgeDB”. Jika database kosong, sistem mengeksekusi script SQL otomatis untuk membuat tabel (“users”, “products”, “categories”, “requests”, “stock_logs”) beserta insert akun default.
5.	Membuat kelas-kelas repository terpisah ([UserRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/UserRepository.cs), [ProductRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/ProductRepository.cs), [RequestRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/RequestRepository.cs)) untuk membungkus perintah SQL Dapper agar tidak mengotori file code-behind UI.
6.	Menulis template visual kontrol WPF (“Styles” dan “ControlTemplates”) untuk mendesain tombol, input textbox rounded, window borderless transparan, serta animasi hover.
7.	Mengaitkan event click tombol UI di file “.xaml.cs” dengan method repository database (misal: login memanggil `UserRepository.Authenticate`).
8.	Membuka socket port 8080 pada server lokal laptop untuk mendengarkan sinyal HTTP Request scanner kamera HP secara asinkron (“Task.Run”).
9.	Memperbaiki kesalahan atau bug yang ditemukan saat pengujian.
10.	Menyusun laporan akhir dan manual book penggunaan aplikasi.

D.	Hasil yang Dicapai
Hasil yang dicapai dari pengerjaan proyek ini adalah sebuah aplikasi manajemen logistik berbasis desktop bernama StockBridge yang dibangun menggunakan C# dan SQL Server. Aplikasi ini berhasil mengintegrasikan manajemen data stok dan keamanan data melalui sistem pembagian hak akses (Role-Based Access Control), serta dilengkapi dengan teknologi QR Code untuk identifikasi barang yang lebih efisien.

1.	Indikator Keberhasilan
Indikator keberhasilan dalam pembuatan aplikasi StockBridge adalah sebagai berikut:
1.	Separasi Akses Role (RBAC): Sistem 100% sukses membatasi menu sidebar navigasi dan memblokir klik fungsi database (Approve/Reject) apabila role yang login tidak berhak (Staff dibatasi).
2.	Konektivitas Mobile Jaringan Lokal: HP di jaringan Wi-Fi yang sama sukses membuka web scanner dari IP laptop dan mengirimkan ID barcode ke laptop secara real-time.
3.	Autentikasi Aman: Logika login berhasil mengenali password ter-hash SHA-256. Percobaan login dengan password salah diblokir dengan aman.
4.	Pencegahan Data Rusak (ACID): Transaksi SQL berhasil di-*rollback* saat stok tidak mencukupi untuk request, menjaga agar stok di database tidak bernilai minus.
5.	Input Sanitization: Aplikasi tidak crash saat diinput data teks pada formulir bertipe angka karena dijaga oleh validasi “TryParse”.
6.	Offline Generator: QR Code dan Barcode sukses digenerate dan disimpan ke penyimpanan lokal saat produk baru didaftarkan.
2.	Tampilan Akhir Program

E.	Manual Book

BAB III
A.	Kesimpulan
Berdasarkan proses perancangan dan pengembangan yang telah dilakukan, dapat disimpulkan bahwa:
1.	Sistem yang Terintegrasi: Proyek ini berhasil merancang aplikasi manajemen inventaris ("StockBridge") yang tidak hanya sekadar mencatat barang, tetapi juga mengelola alur kerja organisasi melalui sistem 3 Role (Admin, Manager, Staff). Hal ini menjamin keamanan data melalui pembatasan hak akses yang jelas.
2.	Efisiensi melalui Teknologi QR Code: Penggunaan library ZXing untuk integrasi QR Code mengubah proses input manual yang lambat menjadi sistem pemindaian yang cepat dan akurat, sehingga meminimalisir risiko human error.
3.	Akuntabilitas Data (Audit Trail): Dengan implementasi tabel StockLogs, setiap pergerakan barang (masuk/keluar) tercatat secara otomatis beserta identitas pelakunya. Hal ini memberikan transparansi penuh bagi pihak manajemen untuk melakukan audit stok kapan saja.
4.	Pemilihan Teknologi yang Tepat: Penggunaan C# WPF dikombinasikan dengan SQL Server dan Dapper terbukti menjadi solusi yang efisien bagi pemula. Sistem ini ringan, tidak memerlukan instalasi server database yang rumit, namun tetap memiliki performa kelas industri.


B.	Saran
Agar aplikasi ini dapat berkembang lebih jauh dan menjadi lebih profesional di masa depan, berikut adalah beberapa saran pengembangan:
1.	Peningkatan Keamanan Data: Untuk pengembangan selanjutnya, sangat disarankan untuk mengimplementasikan Password Hashing (seperti BCrypt atau SHA256) agar data pengguna di dalam database tetap aman meskipun file database jatuh ke tangan yang salah.
2.	Ekspansi Fitur Master Data: Menambahkan tabel Suppliers (Pemasok) dan Locations (Multi-gudang) akan membuat aplikasi ini jauh lebih fleksibel untuk digunakan di perusahaan berskala besar yang memiliki banyak titik distribusi.
3.	Fitur Reporting Otomatis: Menambahkan fitur ekspor laporan ke format PDF atau Excel secara otomatis akan sangat membantu peran Manager dalam mempresentasikan data stok bulanan tanpa harus menyalin data secara manual.
4.	Notifikasi Stok Kritis: Implementasi fitur alert atau notifikasi otomatis ketika stok suatu barang mencapai angka minimal (Threshold) akan sangat membantu operasional agar tidak terjadi kekosongan barang.
