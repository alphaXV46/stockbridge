
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

LEMBAR PENGESAHAN PEMBIMBING GURU MATA PELAJARAN	ii
IDENTITAS SISWA/I PESERTA (ASA)	iii
IDENTITAS SISWA/I PESERTA (GERALDY)	iv
IDENTITAS SISWA/I PESERTA (INDIRA)	v
KATA PENGANTAR	vi
DAFTAR ISI	vii
DAFTAR GAMBAR	ix
DAFTAR TABEL	xi
BAB I PENDAHULUAN	1
A.	Latar Belakang	1
B.	Tujuan	1
C.	Manfaat	2
1.	Manfaat pembuatan Aplikasi	2
2.	Manfaat dari Aplikasi	2
D.	Ruang Lingkup	2
1.	Platform	2
2.	Manajemen Pengguna	2
3.	Manajemen Data	3
4.	Fitur QR Code	3
5.	Database	3
E.	Jenis Pekerjaan	3
BAB II PEMBAHASAN	5
A.	Landasan Teori	5
1.	Aplikasi Manajemen Logistik (StockBridge)	5
2.	Bahasa Pemrograman C#	5
3.	WPF (Windows Presentation Foundation)	5
4.	Dapper Micro-ORM	6
5.	ZXing.Net Library	6
6.	SQL Server & LocalDB	6
7.	Pemrograman Berorientasi Objek (OOP)	6
8.	Use Case Diagram	8
9.	Flowchart	8
10.	Activity Diagram	8
11.	Data Flow Diagram (DFD)	8
12.	Entity Relationship Diagram (ERD)	9
B.	Peralatan yang Digunakan	9
1.	Perangkat Keras (Hardware)	9
2.	Perangkat Lunak (Software)	10
C.	Proses Pengerjaan Membuat Aplikasi StockBridge	11
1.	Class Diagram	11
2.	Use Case Diagram	11
3.	Flowchart	12
4.	Activity Diagram	15
5.	DFD	18
6.	Entity Relation Diagram (ERD)	19
7.	Perancangan Database	19
8.	Perancangan User Interface (UI)	23
9.	Rencana Kerja dan Linimasa (Timeline)	26
10.	Langkah-Langkah Pemrograman	27
D.	Hasil yang Dicapai	29
1.	Indikator Keberhasilan	29
2.	Tampilan Akhir Program	30
E.	Manual Book (Cara Penggunaan)	34
1.	Cara Login	34
2.	Cara Menggunakan Dashboard Admin	34
3.	Cara Menggunakan Dashboard Manager	35
4.	Cara Menggunakan Dashboard Staff	35
5.	Cara Mengelola Data Barang / SKU	36
6.	Cara Melakukan Penyesuaian Stok (Adjust Stock)	36
7.	Cara Mengelola Master Data Satuan (UoM)	37
8.	Cara Mengelola Anggota Tim / User	37
9.	Cara Mengajukan Permintaan Pasokan Barang	38
10.	Cara Menyetujui atau Menolak Permintaan Pasokan	38
11.	Cara Menghubungkan Mobile Scanner (Connect Mobile)	39
12.	Cara Mencetak Label QR Code Barang	39
13.	Cara Logout	40
BAB III PENUTUP	41
A.	Kesimpulan	41
B.	Saran	42
DAFTAR PUSTAKA	43

 
DAFTAR GAMBAR
Gambar 2.1 Class Diagram	11
Gambar 2.2 Use Case Diagram	11
Gambar 2.3 Flowchart Login	12
Gambar 2.4 Flowchart Admin	12
Gambar 2.5 Flowchart Manager	13
Gambar 2.6 Flowchart Staff	13
Gambar 2.7 Flowchart Penyesuaian Stok	14
Gambar 2.8 Flowchart Permintaan Pasokan	14
Gambar 2.9 Activity Diagram Login	15
Gambar 2.10 Activity Diagram Tambah Produk	16
Gambar 2.11 Activity Diagram Penyesuaian Stok	16
Gambar 2.12 Activity Diagram Permintaan Pasokan	17
Gambar 2.13 DFD Level 0 (Context Diagram)	18
Gambar 2.14 DFD Level 1	18
Gambar 2.15 Entity Relationship Diagram (ERD)	19
Gambar 2.16 Perancangan Form Login	23
Gambar 2.17 Perancangan Dashboard Utama	24
Gambar 2.18 Perancangan Form Tambah Produk	24
Gambar 2.19 Perancangan Form Hubungkan Mobile	25
Gambar 2.20 Tampilan Form Login	30
Gambar 2.21 Tampilan Dashboard Navigasi Sidebar	30
Gambar 2.22 Tampilan Halaman Inventaris Barang	31
Gambar 2.23 Tampilan Halaman Log Audit	31
Gambar 2.24 Tampilan Halaman Manajemen User	31
Gambar 2.25 Tampilan Halaman Manajemen Satuan (UoM)	32
Gambar 2.26 Tampilan Form Tambah Barang Baru	32
Gambar 2.27 Tampilan Form Penyesuaian Stok (Adjust Stock)	32
Gambar 2.28 Tampilan Form Permintaan Pasokan (New Request)	33
Gambar 2.29 Tampilan QR Label Print Preview	33
Gambar 2.30 Tampilan Jendela Hubungkan Mobile	33

 
DAFTAR TABEL
Tabel 2.1 Data Pengguna (users)	19
Tabel 2.2 Data Kategori (categories)	20
Tabel 2.3 Data Barang (products)	20
Tabel 2.4 Data Log Transaksi (stock_logs)	21
Tabel 2.5 Data Permintaan Pasokan (requests)	21
Tabel 2.6 Data Satuan (units)	22
Tabel 2.7 Rencana Kerja dan Linimasa (Timeline)	26

 
BAB I
PENDAHULUAN

A.	Latar Belakang
Perkembangan teknologi informasi dan komunikasi saat ini telah membawa perubahan besar pada sistem manajemen operasional di berbagai sektor industri, termasuk dalam bidang manajemen logistik dan pergudangan. Efisiensi, kecepatan, dan akurasi data dalam pelacakan persediaan barang (inventaris) kini menjadi kunci utama bagi keberhasilan operasional perusahaan. Dengan adanya sistem yang terkomputerisasi, pencatatan dan pemantauan arus barang dapat dilakukan dengan lebih cepat dan transparan.

Namun, pada kenyataannya masih banyak gudang atau unit usaha yang menggunakan metode manual dalam pencatatan persediaan barang mereka, baik menggunakan buku besar fisik maupun aplikasi spreadsheet sederhana seperti Microsoft Excel. Metode ini memiliki berbagai kelemahan signifikan, antara lain risiko kesalahan manusia (human error) yang tinggi saat menginput data secara manual, lambatnya pencarian informasi produk, kesulitan dalam memverifikasi kecocokan stok fisik dengan data digital, serta tidak adanya riwayat log audit (audit trail) yang jelas untuk melacak aktivitas pengguna sistem. Selain itu, keterbatasan dalam hak akses pengguna dapat memicu kebocoran data sensitif jika semua orang bebas memodifikasi data persediaan.

Guna mengatasi permasalahan tersebut, dibutuhkan sebuah sistem manajemen logistik terintegrasi yang mampu mengotomatisasi pencatatan stok, menjamin keamanan data lewat pembatasan hak akses (Role-Based Access Control), dan mempercepat proses input/output barang. Oleh karena itu, penulis merancang dan membangun sebuah aplikasi manajemen logistik berbasis desktop yang diberi nama StockBridge. Aplikasi ini dibangun menggunakan bahasa pemrograman C# dengan framework Windows Presentation Foundation (WPF) untuk menghasilkan antarmuka pengguna yang modern dan responsif, serta didukung oleh database SQL Server LocalDB dan micro-ORM Dapper untuk memastikan performa pengolahan data yang cepat dan andal.

Selain fitur manajemen data stok standar, StockBridge juga mengintegrasikan teknologi QR Code menggunakan library ZXing.Net untuk mempermudah identifikasi barang secara nirkabel. Aplikasi ini dilengkapi dengan asynchronous HTTP server listener pada port 8080, yang memungkinkan perangkat smartphone di jaringan lokal yang sama bertindak sebagai pemindai barcode nirkabel tanpa perlu mematikan firewall atau mengonfigurasi flags HTTPS di browser. Melalui solusi terintegrasi ini, diharapkan pengelolaan logistik barang dapat berjalan dengan lebih efisien, terstruktur, aman, dan meminimalkan kesalahan operasional.

B.	Tujuan
Tujuan dari pembuatan aplikasi manajemen logistik StockBridge adalah:
1.	Membangun aplikasi manajemen logistik (StockBridge) berbasis desktop menggunakan teknologi C# WPF (Windows Presentation Foundation) dan database SQL Server LocalDB.
2.	Mengimplementasikan sistem keamanan data berbasis pembagian peran pengguna (Role-Based Access Control) yang terenkripsi menggunakan algoritma SHA-256 untuk membatasi hak akses Admin, Manager, dan Staff secara dinamis.
3.	Mengembangkan fitur sinkronisasi pemindaian barcode/QR Code nirkabel melalui web listener HTTP server lokal (port 8080) menggunakan perangkat smartphone secara real-time.
4.	Mengintegrasikan pustaka ZXing.Net untuk menghasilkan label QR Code dan barcode produk secara offline guna mempermudah proses stok opname dan identifikasi barang.
5.	Menerapkan logika konversi satuan barang (Unit of Measurement) dinamis untuk mempermudah perhitungan transaksi eceran (Unit) maupun kemasan grosir (Pack).

C.	Manfaat
1.	Manfaat pembuatan Aplikasi
Proses pengerjaan ini mengasah logika C# dan manajemen database kami melalui  kerja tim yang profesional. Selain meningkatkan skill teknis, proyek ini menjadi portofolio nyata yang membuktikan bahwa solusi digital berkualitas dapat dibangun secara efektif dengan biaya yang sangat minim.
2.	Manfaat dari Aplikasi
Aplikasi ini meningkatkan akurasi data stok dengan menghilangkan kesalahan manualserta mempercepat operasional gudang melalui fitur scan QR Code. Sistem ini juga menjamin keamanan data lewat pembatasan hak akses pengguna dan menyediakan laporan otomatis yang transparan untuk mempermludah pengambilan keputusan.
D.	Ruang Lingkup
1.	Platform
Aplikasi StockBridge berjalan secara eksklusif pada sistem operasi Microsoft Windows (Desktop Client Architecture) yang dibangun menggunakan teknologi .NET Framework 4.8. Pemilihan platform desktop ini memastikan aplikasi dapat berjalan secara mandiri (standalone), responsif, dan terintegrasi penuh dengan pustaka grafis Windows Presentation Foundation (WPF).
2.	Manajemen Pengguna
Menggunakan sistem Role-Based Access Control (RBAC) yang terbagi menjadi tiga peran utama dengan hak akses terproteksi:
-	Admin: Memiliki otoritas penuh sistem untuk mengelola data inventaris (SKU), mengelola pengguna (tambah, edit, hapus user), memantau log audit transaksi, serta mengonfigurasi master data satuan (UoM).
-	Manager: Memiliki hak pengawasan gudang penuh, meliputi melihat daftar inventaris barang, meninjau log audit mutasi barang, serta menyetujui atau menolak permohonan pasokan barang yang diajukan oleh Staff.
-	Staff: Memiliki hak operasional terbatas, hanya dapat mencari dan melihat data inventaris barang serta membuat form pengajuan permintaan pasokan barang baru ke gudang.
3.	Manajemen Data
Mengelola database relasional terstruktur yang terdiri dari 6 tabel utama: tabel pengguna (users) untuk keamanan login, tabel kategori (categories) untuk pengelompokan produk, tabel barang (products) untuk detail SKU, tabel log transaksi (stock_logs) untuk riwayat audit persediaan, tabel permintaan pasokan (requests) untuk alur pengadaan barang, dan tabel satuan (units) untuk pengelolaan unit pengukuran resmi.
4.	Fitur QR Code
Aplikasi mengintegrasikan pustaka ZXing.Net untuk menghasilkan label QR Code dan barcode produk secara offline dan otomatis saat produk baru didaftarkan. Selain itu, aplikasi menyediakan server HTTP listener lokal pada port 8080 untuk menangkap data scan QR Code dari smartphone secara nirkabel di jaringan Wi-Fi yang sama.
5.	Database
Menggunakan Microsoft SQL Server Express LocalDB sebagai mesin basis data relasional lokal yang ringan, berjalan di dalam mode pengguna (user mode) tanpa overhead server penuh, namun tetap mendukung transaksi data ACID dan query Transact-SQL standar industri.

E.	Jenis Pekerjaan
Jenis pekerjaan dalam pelaksanaan proyek pembuatan aplikasi Manajemen Logistik (StockBridge) ini meliputi:
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
Tugas utama meliputi melakukan observasi dan analisis kebutuhan sistem logistik, memodelkan proses bisnis menggunakan diagram UML (Class, Use Case, Activity) serta diagram DFD dan ERD, mengumpulkan data inventaris awal untuk data seeding basis data, menyusun manual book cara penggunaan aplikasi, serta menyusun dan merapikan dokumen laporan tugas akhir secara terstruktur.
2.	Backend Developer: Geraldy Febriansyah
Tugas utama meliputi merancang skema database relasional di SQL Server Management Studio, mengimplementasikan logika self-healing database dan data seeding pada C# class helper, menulis instruksi transaksi database ter-kapsulasi menggunakan Dapper ORM untuk repositori data, mengembangkan asinkron socket server HTTP listener pada port 8080 untuk scanner mobile, serta melakukan pengujian konektivitas data.
3.	Frontend Developer: Indira
Tugas utama meliputi membuat konsep desain mockup antarmuka pengguna, menerjemahkan mockup menjadi kode layout XAML berbasis split-pane dashboard dan jendela modal dialog, menyusun styles resource dictionary terpusat (ModernTheme.xaml) untuk custom control template, menghubungkan data binding dari backend repositori ke elemen DataGrid WPF, serta mengimplementasikan visual badge status dinamis.




BAB II
A.	Landasan Teori
1.	Aplikasi Manajemen Logistik (StockBridge)
Aplikasi manajemen logistik adalah sistem informasi perangkat lunak yang dirancang untuk mempermudah, mengontrol, dan memantau pergerakan serta penyimpanan barang (inventaris) di dalam suatu gudang atau organisasi. Sistem ini membantu pencatatan barang masuk (inbound), barang keluar (outbound), pencatatan stok saat ini, riwayat log audit, dan permintaan pasokan. Dalam proyek ini, aplikasi manajemen logistik yang dikembangkan bernama StockBridge. StockBridge membantu mengotomatisasi pencatatan manual yang rentan terhadap kesalahan manusia (human error), mengintegrasikan pemindaian kode unik QR/Barcode dengan perangkat eksternal, dan menerapkan kontrol keamanan akses data untuk mencegah kebocoran informasi.
2.	Bahasa Pemrograman C#
Menurut Microsoft Learn, C# (C-Sharp) adalah bahasa pemrograman modern, aman type-safe, dan berorientasi objek yang berjalan di atas .NET runtime. Bahasa C# menggabungkan kekuatan komputasi C++ dengan kemudahan pemrograman Visual Basic. Dalam pembuatan aplikasi StockBridge, bahasa C# digunakan sebagai backend logic (code-behind) untuk memproses input pengguna, melakukan operasi CRUD ke database SQL Server melalui Dapper, mengontrol aliran logika autentikasi pengguna, melakukan kalkulasi matematika untuk konversi satuan barang, dan merespons interaksi antarmuka pengguna secara asinkron.
3.	WPF (Windows Presentation Foundation)
Windows Presentation Foundation (WPF) adalah framework UI buatan Microsoft yang digunakan untuk membangun aplikasi desktop klien Windows yang kaya akan grafik dan interaksi. WPF menggunakan konsep pemisahan antara desain antarmuka (UI) menggunakan bahasa deklaratif XAML (Extensible Application Markup Language) dan logika backend (code-behind) menggunakan bahasa C#. WPF mendukung fitur modern seperti data binding dua arah, styling terpusat (Styles & Resource Dictionaries), control templates untuk merancang ulang elemen standar seperti DataGrid atau ComboBox, dan efek grafis terakselerasi perangkat keras (hardware-accelerated graphics). Pada aplikasi StockBridge, WPF digunakan sebagai fondasi utama antarmuka pengguna untuk menciptakan dashboard modern dengan sudut membulat (rounded corners), perataan kolom DataGrid yang rapi, dan transisi visual yang responsif.
4.	Dapper Micro-ORM
Dapper adalah pustaka Micro Object-Relational Mapper (ORM) sumber terbuka (open-source) untuk bahasa pemrograman C#/.NET. Berbeda dengan ORM besar seperti Entity Framework yang memiliki overhead performa tinggi, Dapper dirancang dengan fokus utama pada kecepatan eksekusi query SQL yang mendekati kecepatan ADO.NET mentah. Dapper bekerja dengan cara memetakan hasil query SQL relasional langsung ke objek C# (dynamic maupun ber-tipe data) secara efisien melalui metode ekstensi pada objek IDbConnection. Dalam aplikasi StockBridge, Dapper digunakan untuk berinteraksi dengan SQL Server, memproses login pengguna, mengambil daftar barang, mencatat log audit stok, dan memperbarui status permintaan pasokan secara aman dengan parameter ter-kapsulasi untuk menghindari SQL Injection.
5.	ZXing.Net Library
ZXing.Net (Zebra Crossing .NET) adalah pustaka porting dari pustaka pemrosesan gambar barcode 1D/2D Java ZXing yang populer untuk platform .NET. Pustaka ini mendukung pembuatan (generation) dan pembacaan (scanning) berbagai format barcode standar secara offline, seperti QR Code dan CODE_128. Pada aplikasi StockBridge, ZXing.Net digunakan untuk secara otomatis membuat gambar file PNG QR Code (yang menyimpan tautan sinkronisasi HTTP server lokal) dan Barcode CODE_128 (yang menyimpan ID produk) secara instan ketika admin menambahkan barang baru ke dalam database.
6.	SQL Server & LocalDB
Microsoft SQL Server adalah Sistem Manajemen Basis Data Relasional (RDBMS) kelas industri yang dikembangkan oleh Microsoft untuk menyimpan dan mengelola data dalam jumlah besar dengan keamanan ACID (Atomicity, Consistency, Isolation, Durability) yang kuat. Untuk keperluan pengembangan lokal dan demonstrasi tanpa konfigurasi server yang rumit, proyek StockBridge memanfaatkan SQL Server Express LocalDB. LocalDB adalah versi ringan dari SQL Server yang berjalan sebagai proses pengguna (user mode) secara instan, tidak memerlukan layanan latar belakang Windows yang berjalan terus-menerus, namun tetap menggunakan syntax Transact-SQL (T-SQL) yang sama dengan SQL Server versi penuh.

7.	Pemrograman Berorientasi Objek (OOP)
Pemrograman Berorientasi Objek (Object-Oriented Programming / OOP) adalah paradigma pemrograman yang berorientasi pada konsep "objek" yang berisi data (dalam bentuk atribut/field) dan kode (dalam bentuk prosedur/method). Bahasa C# mendukung penuh paradigma OOP ini. Konsep-konsep utama OOP yang diimplementasikan dalam StockBridge meliputi:
a.	Class: Merupakan cetakan biru (blueprint) atau template yang mendefinisikan atribut dan perilaku dari objek yang akan dibuat. Contohnya adalah kelas DatabaseHelper, UserRepository, ProductRepository, dan kelas-kelas window.
b.	Object: Merupakan instansiasi nyata dari sebuah Class yang memiliki state dan data aktif. Contohnya adalah instansi window dari AddProductWindow yang dibuat saat tombol tambah ditekan.
c.	Encapsulation: Merupakan konsep pembungkusan data dan method di dalam suatu unit (class) untuk menyembuyen detail implementasi internal dari luar. Di StockBridge, enkapsulasi dilakukan dengan membungkus instruksi database Dapper di dalam kelas repository (seperti ProductRepository) sehingga kode UI (code-behind) hanya memanggil method bersih tanpa mengetahui proses SQL di dalamnya.
d.	Inheritance: Merupakan pewarisan sifat di mana sebuah kelas (subclass/child class) dapat mewarisi atribut dan method dari kelas lain (superclass/parent class). Contohnya di WPF, semua kelas Page (seperti InventoryPage, RequestPage) mewarisi langsung dari kelas dasar System.Windows.Controls.Page.
e.	Polymorphism: Merupakan kemampuan suatu objek untuk memiliki banyak bentuk, yang memungkinkan pemrosesan perilaku yang berbeda untuk tipe data yang berbeda meskipun menggunakan nama method yang sama. Di StockBridge, polimorfisme diterapkan dalam hak akses pengguna, di mana role Admin, Manager, dan Staff memiliki hak akses dan tampilan dashboard yang disesuaikan secara dinamis meskipun melakukan autentikasi login melalui alur penanganan yang sama.

8.	Use Case Diagram
Use Case Diagram adalah diagram UML (Unified Modeling Language) yang menggambarkan interaksi antara aktor (pengguna sistem) dengan kasus penggunaan (use case) atau fungsionalitas yang disediakan oleh sistem. Diagram ini memberikan pemahaman tingkat tinggi tentang batasan hak akses pengguna. Dalam StockBridge, diagram ini memetakan aksi Admin (mengelola produk, pengguna, UoM, melihat log), Manager (melihat inventaris, log, menyetujui/menolak permintaan stok), dan Staff (melihat barang, mengajukan permintaan stok).

9.	Flowchart
Flowchart adalah diagram alir visual yang menggunakan simbol-simbol standar geometris untuk menggambarkan urutan langkah-langkah logis dari suatu proses atau algoritma dari awal hingga akhir. Flowchart membantu memvisualisasikan keputusan logis (decision blocks) di dalam aplikasi, seperti validasi username/password pada alur login, atau perhitungan pengali konversi satuan saat melakukan penyesuaian stok.

10.	Activity Diagram
Activity Diagram adalah diagram UML yang memodelkan alur kerja (workflow) atau aktivitas prosedural dari suatu sistem secara dinamis. Berbeda dengan flowchart yang berfokus pada logika pemrograman internal, activity diagram berfokus pada interaksi alur kerja antara pengguna dengan respon yang diberikan oleh sistem, termasuk proses paralel dan sinkronisasi data.

11.	Data Flow Diagram (DFD)
Data Flow Diagram (DFD) adalah representasi grafis yang menggambarkan aliran data melalui suatu sistem informasi. DFD memetakan bagaimana data masuk ke dalam sistem, diproses oleh fungsi-fungsi tertentu, disimpan dalam penyimpanan data (data store seperti tabel database), dan akhirnya menghasilkan keluaran informasi bagi pengguna. DFD dibagi menjadi beberapa tingkat, dimulai dari Diagram Konteks (Level 0) hingga DFD Level 1 yang lebih mendetail.

12.	Entity Relationship Diagram (ERD)
Entity Relationship Diagram (ERD) adalah diagram yang digunakan untuk merancang dan memodelkan struktur basis data relasional. ERD mendefinisikan entitas (tabel data), atribut (kolom/field), serta hubungan kardinalitas relasional (seperti satu-ke-banyak atau one-to-many) antar tabel melalui kunci utama (Primary Key) dan kunci tamu (Foreign Key) untuk menjamin integritas referensial data.

13.	Class Diagram
Class Diagram adalah diagram UML yang menggambarkan struktur statis sistem dengan menampilkan kelas-kelas yang ada, atributnya, methodnya, serta hubungan antar kelas (seperti asosiasi, pewarisan, atau dependensi). Diagram ini memetakan arsitektur kode C# di dalam aplikasi, khususnya struktur data model dan interaksi antar repositori logis aplikasi StockBridge. 

B.	Peralatan yang Digunakan
Peralatan yang Digunakan untuk membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server, yaitu:
1.	Perangkat Keras:
a)	Laptop/PC:
1)	Prosesor: Minimal Intel Core i3 (Generasi 8 ke atas) atau AMD Ryzen 3.
2)	RAM: Minimal 8 GB (Sangat disarankan karena Visual Studio dan SQL Server cukup memakan memori).
3)	Penyimpanan: SSD sangat disarankan (minimal sisa ruang 20 GB) agar proses buka-tutup aplikasi cepat.
b)	Mouse: Untuk memudahkan desain antarmuka (UI) di WPF/XAML.
c)	Smartphone: Digunakan sebagai alat pemindai (scanner) QR Code/Barcode untuk simulasi integrasi perangkat mobile.
d)	Koneksi Internet: Untuk mengunduh library (NuGet Packages) dan koordinasi tim via GitHub.
e)	Printer (Opsional): Jika ingin menguji hasil cetak label QR Code secara fisik.

2.	Perangkat Lunak:
a)	Sistem Operasi: Windows 10 atau Windows 11. Digunakan sebagai sistem operasi utama karena aplikasi StockBridge dirancang secara native menggunakan Windows Presentation Foundation (WPF) yang berjalan optimal pada lingkungan Windows.
b)	IDE (Integrated Development Environment): Microsoft Visual Studio 2019 atau 2022 dengan workload ".NET Desktop Development" yang diinstal. Visual Studio bertindak sebagai IDE utama untuk menulis kode C#, mendesain antarmuka XAML, serta mengelola dependensi package NuGet.
c)	Database System:
1)	SQL Server Express LocalDB: Sebagai mesin database relasional lokal yang ringan untuk menyimpan seluruh data terstruktur.
2)	SQL Server Management Studio (SSMS): Digunakan untuk melakukan administrasi database, verifikasi query T-SQL, serta memantau integritas tabel secara visual.
d)	Library & Framework:
1)	.NET Framework 4.8: Sebagai kerangka kerja perangkat lunak utama yang menyediakan runtime environment.
2)	Dapper Micro-ORM (versi 2.0+): Library ORM ringan untuk memetakan database ke objek C# secara cepat.
3)	ZXing.Net Library: Pustaka khusus untuk meng-generate gambar barcode dan QR Code produk secara offline.

C.	Proses pengerjaan membuat Aplikasi Manajemen Logistik (Stockbridge) Berbasis Desktop menggunakan C# dengan Database SQL Server
1.	Class Diagram
 
Gambar 2.1 Class Diagram
Class diagram memetakan struktur data statis dan hubungan antar-kelas (dependency, association, inheritance) di dalam kode program StockBridge. Diagram ini memperlihatkan kelas model data seperti User, Product, Category, Request, StockLog, dan Unit, serta kelas helper DatabaseHelper dan repositori seperti UserRepository, ProductRepository, RequestRepository, dan UnitRepository yang memuat logika query Dapper untuk berinteraksi dengan database.

2.	Use Case Diagram
 
Gambar 2.2 Use Case Diagram
Use Case diagram mendefinisikan batas sistem dan interaksi antara tiga aktor utama (Admin, Manager, Staff) dengan kasus penggunaan aplikasi. Admin memiliki akses ke seluruh fungsionalitas (mengelola produk, pengguna, unit, melihat log). Manager berfokus pada pengawasan persediaan, verifikasi log transaksi, dan persetujuan permintaan stok. Staff hanya berhak melihat barang dan mengajukan permintaan pasokan baru.

3.	Flowchart
a.	Flowchart Login
 
Gambar 2.3 Flowchart Login
Menggambarkan alur logis autentikasi pengguna dimulai dari input username dan password, pencocokan data ke database menggunakan kueri Dapper, validasi enkripsi hash SHA-256, hingga penentuan hak akses peran pengguna sebelum masuk ke dashboard.

b.	Flowchart Admin
 
Gambar 2.4 Flowchart Admin
Menjelaskan alur keputusan dan navigasi peran Admin yang mencakup menu lengkap sistem seperti pengelolaan inventaris SKU, manajemen pengguna tim, riwayat audit trail, serta konfigurasi master data satuan.

c.	Flowchart Manager
 
Gambar 2.5 Flowchart Manager
Menjelaskan alur navigasi peran Manager yang terbatas pada pengawasan inventaris, pemrosesan persetujuan pengajuan pasokan (Approve/Reject), dan pengecekan riwayat mutasi stok.

d.	Flowchart Staff
 
Gambar 2.6 Flowchart Staff
Menggambarkan alur kerja Staff yang sangat terbatas, di mana Staff hanya dapat mencari data produk pada inventaris dan mengajukan permohonan pasokan barang baru.

e.	Flowchart Penyesuaian Stok
 
Gambar 2.7 Flowchart Penyesuaian Stok
Menjelaskan logika perhitungan penyesuaian kuantitas stok barang masuk/keluar, di mana sistem mendeteksi tipe satuan (Unit atau Pack) dan secara otomatis mengalikannya dengan rate konversi produk sebelum memperbarui database.

f.	Flowchart Permintaan Pasokan
 
Gambar 2.8 Flowchart Permintaan Pasokan
Menggambarkan proses pengajuan pasokan barang dari sisi Staff, dilanjutkan dengan penyimpanan data status 'Pending' pada database, hingga verifikasi dan perubahan status oleh Manager.

4.	Activity Diagram
a.	Activity Diagram Login
 
Gambar 2.9 Activity Diagram Login
Menggambarkan urutan aktivitas interaktif antara pengguna (mengisi form) dengan respon sistem (validasi database, menampilkan pesan error jika salah, atau membuka dashboard yang sesuai jika benar).

b.	Activity Diagram Tambah Produk
 
Gambar 2.10 Activity Diagram Tambah Produk
Menggambarkan aktivitas penambahan SKU baru, mulai dari pengisian formulir, validasi input angka (TryParse), rendering label QR Code secara offline oleh ZXing.Net, hingga penyimpanan record baru ke database.

c.	Activity Diagram Penyesuaian Stok
 
Gambar 2.11 Activity Diagram Penyesuaian Stok
Menggambarkan aktivitas operasional penyesuaian stok opname, mulai dari pemilihan barang pada DataGrid, pengisian form penyesuaian, perhitungan konversi kemasan besar, hingga penulisan log transaksi stok secara otomatis.

d.	Activity Diagram Permintaan Pasokan
 
Gambar 2.12 Activity Diagram Permintaan Pasokan
Menggambarkan alur kolaboratif pengajuan pasokan, dimulai dari pembuatan request oleh Staff, notifikasi data masuk di dashboard Manager, proses persetujuan oleh Manager, hingga pembaruan stok produk otomatis.

5.	DFD
a.	DFD Level 0 (Context Diagram)
 
Gambar 2.13 DFD Level 0 (Context Diagram)
Memetakan aliran data global antara entitas luar (Admin, Manager, Staff) dengan sistem utama StockBridge, memperlihatkan data masukan kredensial, request pasokan, penyesuaian stok, serta keluaran informasi laporan log.

b.	DFD Level 1
 
Gambar 2.14 DFD Level 1
Menguraikan proses internal DFD Level 0 menjadi proses-proses terperinci seperti Proses Login, Kelola Inventaris, Kelola Transaksi, Pemrosesan Request, dan Pemrosesan Log audit ke masing-masing penyimpanan data (data store).

6.	Entity Relation Diagram (ERD)
 
Gambar 2.15 Entity Relationship Diagram (ERD)
Menggambarkan struktur basis data relasional logis dengan mendefinisikan kunci utama, kunci tamu, serta kardinalitas relasi antar-tabel (seperti categories-to-products dan products-to-stock_logs) demi menjamin integritas referensial data.

 
7.	Perancangan Database
Perancangan database dilakukan untuk menentukan tabel, field, tipe data, primary key, foreign key, dan relasi antar tabel. Database yang digunakan dalam aplikasi StockBridge adalah SQL Server. Berdasarkan struktur database yang diimplementasikan secara otomatis dalam kode program C#, aplikasi StockBridge memiliki 6 tabel utama untuk menyimpan data terstruktur, yaitu tabel users, categories, products, stock_logs, requests, dan units.

a.	Tabel Pengguna (users)
Tabel users digunakan untuk menyimpan data kredensial pengguna aplikasi, tingkat otorisasi (role), dan pengaturan keamanan untuk masuk ke sistem.
Tabel 2.1 Data Pengguna (users)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| id | INT | Primary Key (Identity) | ID unik otomatis untuk setiap pengguna |
| username | NVARCHAR(100) | Unique | Nama pengguna untuk kredensial masuk |
| password | NVARCHAR(100) | - | Kata sandi pengguna yang terenkripsi SHA-256 |
| role | NVARCHAR(50) | - | Peran akses pengguna (Admin, Manager, Staff) |

b.	Tabel Kategori (categories)
Tabel categories digunakan untuk menyimpan daftar klasifikasi kategori barang dagang demi kerapian pengelompokan inventaris.
Tabel 2.2 Data Kategori (categories)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| id | INT | Primary Key (Identity) | ID unik otomatis untuk setiap kategori barang |
| category_name | NVARCHAR(100) | - | Nama kategori barang (contoh: Elektronik, ATK) |

c.	Tabel Barang (products)
Tabel products digunakan untuk mengelola detail informasi produk inventaris secara lengkap, termasuk informasi barcode, harga, deskripsi, dan aturan konversi kemasan satuan.
Tabel 2.3 Data Barang (products)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| id | NVARCHAR(100) | Primary Key | Kode SKU/ID unik barang atau nilai Barcode |
| product_name | NVARCHAR(255) | - | Nama deskriptif barang/produk |
| category_id | INT | Foreign Key | Berelasi ke tabel categories(id) |
| base_stock | INT | - | Jumlah stok barang saat ini dalam satuan terkecil |
| unit_name | NVARCHAR(50) | - | Nama satuan terkecil/dasar (contoh: Pcs, Rim) |
| pack_name | NVARCHAR(50) | - | Nama satuan kemasan besar (contoh: Dus, Box) |
| conversion_rate | INT | - | Nilai pengali konversi satuan (jumlah unit per pack) |
| price | DECIMAL(18,2) | - | Harga beli produk (dalam Rupiah) |
| description | NVARCHAR(MAX) | - | Keterangan lengkap atau catatan produk |
| created_at | DATETIME | - | Tanggal pembuatan produk (Default: GETDATE()) |

d.	Tabel Log Transaksi (stock_logs)
Tabel stock_logs digunakan untuk menyimpan catatan log audit (audit trail) setiap pergerakan barang (stok masuk dan keluar) demi akuntabilitas operasional.
Tabel 2.4 Data Log Transaksi (stock_logs)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| log_id | INT | Primary Key (Identity) | ID unik otomatis untuk baris log audit |
| product_id | NVARCHAR(100) | Foreign Key | ID produk yang terlibat (berelasi ke products.id) |
| type | NVARCHAR(50) | - | Jenis transaksi pergerakan barang (Masuk / Keluar) |
| quantity | INT | - | Jumlah kuantitas transaksi yang diinput oleh user |
| total_affected | INT | - | Total stok dalam satuan terkecil yang berubah |
| created_at | DATETIME | - | Tanggal pencatatan transaksi (Default: GETDATE()) |

e.	Tabel Permintaan Pasokan (requests)
Tabel requests digunakan untuk menyimpan data pengajuan pengadaan barang/stok baru yang diajukan oleh Staff dan membutuhkan peninjauan (approval) dari Manager.
Tabel 2.5 Data Permintaan Pasokan (requests)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| id | INT | Primary Key (Identity) | ID unik pengajuan permintaan pasokan |
| product_name | NVARCHAR(255) | - | Nama barang yang diminta |
| qty_requested | INT | - | Jumlah kuantitas barang yang diminta |
| status | NVARCHAR(50) | - | Status verifikasi pengajuan (Pending, Approved, Rejected) |

f.	Tabel Satuan (units)
Tabel units digunakan sebagai tabel master data tipe satuan pengukuran resmi yang terdaftar untuk validasi pengisian produk.
Tabel 2.6 Data Satuan (units)
| Nama Field | Tipe Data | Kunci | Keterangan |
| :--- | :--- | :--- | :--- |
| id | INT | Primary Key (Identity) | ID unik otomatis master data satuan |
| unit_code | NVARCHAR(50) | Unique | Kode ringkas satuan (contoh: Pcs, Dus, Kg) |
| unit_name | NVARCHAR(100) | - | Nama deskripsi lengkap (contoh: Pieces, Kilogram) |

g.	Relasi Antar Tabel (Foreign Keys)
Hubungan antar tabel dalam database StockBridge dirancang secara relasional untuk memastikan integritas data (ACID):
1.	Kolom `products.category_id` memiliki hubungan satu-ke-banyak (*one-to-many*) ke tabel `categories.id` untuk penentuan klasifikasi barang.
2.	Kolom `stock_logs.product_id` memiliki hubungan satu-ke-banyak (*one-to-many*) ke tabel `products.id` untuk mencatat riwayat mutasi stok produk. Jika produk dihapus, database akan menolaknya demi mencegah *orphaned records*.
3.	Hubungan referensial juga diterapkan pada level aplikasi untuk memblokir penghapusan master data satuan pada tabel `units` apabila kode satuan tersebut sedang aktif digunakan di kolom `products.unit_name` atau `products.pack_name`.

h.	Self-Healing Database & Seeding
Aplikasi StockBridge menerapkan prinsip *Self-Healing Database* untuk menjamin kemudahan instalasi oleh pengguna akhir tanpa memerlukan konfigurasi database manual yang rumit. Pada saat program dijalankan (startup), sistem secara otomatis melakukan koneksi awal ke database system `master` SQL Server LocalDB. Koneksi ini bertujuan untuk mendeteksi keberadaan basis data `StockBridgeDB` di dalam server. Apabila basis data tersebut belum terbentuk, program akan secara otomatis mengeksekusi perintah SQL `CREATE DATABASE StockBridgeDB` dan menginisialisasi seluruh skema tabel relasional (users, categories, products, stock_logs, requests, units) beserta foreign key dan constraints-nya.

Setelah skema basis data berhasil dibentuk dengan sempurna, sistem akan melanjutkan proses dengan pengisian data awal (*seeding data*). Data awal ini mencakup akun pengguna bawaan dengan sandi ter-enkripsi SHA-256 (username `admin`, `manager`, dan `staff`), klasifikasi kategori awal (`Elektronik`, `IT Asset`, `ATK`), serta kode satuan dasar (`Pcs`, `Dus`, `Kg`, `Meter`, `Rim`). Jika database sudah ada dari sesi sebelumnya, langkah self-healing ini akan dilewati secara otomatis dan program langsung memuat halaman login utama.
8.	User Interface (UI)
a.	Perancangan Form Login
 
Gambar 2.16 Perancangan Form Login
1)	Layout: Menggunakan skema centered card login layout. Terdapat sebuah wadah panel kotak putih di tengah layar dengan sudut membulat (corner radius), memberikan bayangan halus (drop shadow) di atas latar belakang abu-abu terang.
2)	Kontrol Konten: Di bagian atas diisi logo inisial "SB" berwarna biru, nama aplikasi "STOCKBRIDGE", dan sub-label "Supplier Management System". Di bagian input, terdapat isian teks "Username" (TextBox biasa) dan "Password" (WPF PasswordBox dengan ikon mata di ujung kanan untuk mengintip isian teks). Di bagian bawah terdapat tombol utama "SIGN IN" berwarna gelap, diikuti tombol sekunder merah "KELUAR APLIKASI".

b.	Perancangan Dashboard Utama
 
Gambar 2.17 Perancangan Dashboard Utama
1)	Layout: Menggunakan tata letak panel ganda (split-pane dashboard). Sisi kiri selebar 250px adalah kolom statis sidebar navigasi berwarna biru gelap/gelap, sedangkan sisi kanan yang lebih luas adalah area dinamis (`WPF Frame`) untuk memuat halaman.
2)	Kontrol Konten: Di bagian atas sidebar terdapat inisial pengguna aktif dan peran hak aksesnya (misal: "Welcome, Admin"). Di bagian tengah menu navigasi berupa tombol teks (Inventory, Request, Logs, Connect Mobile, Users) yang visibilitasnya akan disembunyikan otomatis oleh sistem berdasarkan hak akses yang login. Bagian kanan atas berisi tombol mini kontrol window (Minimize, Maximize, Close).

c.	Perancangan Form Tambah Produk
 
Gambar 2.18 Perancangan Form Tambah Produk
1)	Layout: Jendela modal pop-up berukuran medium yang muncul tepat di tengah layar pemilik aplikasi (*Center Owner*), dihiasi efek bayangan gelap tipis di tepian luar jendela.
2)	Kontrol Konten: Judul utama "TAMBAH PRODUK BARU" diletakkan di pojok kiri atas. Di area formulir, isian dibagi menjadi dua kolom. Kolom kiri memuat input Kode Barang, Nama Produk, dan Harga Beli (dalam Rupiah). Kolom kanan memuat ComboBox pilihan Kategori Barang dan TextBox untuk jumlah Stok Awal. Di bagian bawah terdapat input area deskripsi barang, area konversi satuan (memilih satuan eceran unit pcs, satuan kemasan dus, dan rate konversinya), serta tombol aksi "BATAL" dan "SIMPAN".

d.	Perancangan Form Hubungkan Mobile
 
Gambar 2.19 Perancangan Form Hubungkan Mobile
1)	Layout: Kotak dialog modal berdimensi kecil di tengah layar, didominasi warna putih bersih dengan aksen biru muda.
2)	Kontrol Konten: Menampilkan judul "Hubungkan Handphone". Area tengah diisi secara penuh oleh gambar QR Code yang dihasilkan secara lokal (offline) berisi alamat IP lokal komputer tempat aplikasi berjalan (contoh: `http://192.168.1.15:8080/`). Di bawah QR Code terdapat teks informasi alamat server aktif untuk input alternatif, serta tombol "TUTUP" di sisi kanan bawah.
9.	Rencana Kerja dan Linimasa (Timeline)
Rencana kerja dan linimasa dibuat agar proses pengerjaan aplikasi StockBridge berjalan secara terstruktur, terarah, dan selesai tepat waktu.
Tabel 2.7 Rencana Kerja dan Linimasa (Timeline)
| No | Kegiatan | Waktu Pelaksanaan | Penanggung Jawab |
| :--- | :--- | :--- | :--- |
| 1 | Analisis kebutuhan sistem pergudangan | Minggu ke-1 | Semua anggota |
| 2 | Perancangan arsitektur sistem (Use Case, Flowchart, DFD, ERD) | Minggu ke-1 & 2 | Dokumentasi (Asa Enggal) |
| 3 | Perancangan skema database & relasi tabel SQL Server | Minggu ke-2 | Backend (Geraldy Febriansyah) |
| 4 | Pembuatan mockup & implementasi UI XAML (Login, Dashboard) | Minggu ke-3 | Frontend (Indira) |
| 5 | Pembuatan UI XAML halaman utama (Inventory, Logs, User, UoM) | Minggu ke-4 | Frontend (Indira) |
| 6 | Pemrograman logika backend repository (Dapper & SQL Server) | Minggu ke-4 & 5 | Backend (Geraldy Febriansyah) |
| 7 | Integrasi QR Code generator & http listener mobile sync | Minggu ke-5 & 6 | Backend (Geraldy Febriansyah) |
| 8 | Implementasi data binding & dynamic unit conversion logic | Minggu ke-6 | Frontend & Backend |
| 9 | Pengujian sistem (Black-box testing) & perbaikan bug | Minggu ke-7 | Semua anggota |
| 10 | Penyusunan laporan tugas akhir & manual book | Minggu ke-8 | Dokumentasi (Asa Enggal) |

10.	Langkah-Langkah Pemrograman
Langkah-langkah pemrograman dalam pembuatan aplikasi StockBridge adalah sebagai berikut:
1.	Membuat proyek baru di Microsoft Visual Studio berbasis WPF Application (.NET Framework 4.8) dengan format SDK-style “.csproj” agar dependensi pustaka terkelola dengan rapi melalui NuGet.
2.	Menginstal micro-ORM Dapper (versi 2.1.72) melalui Package Manager Console dengan perintah:
      ```powershell
      Install-Package Dapper
      ```
3.	Menginstal pustaka QR/Barcode generator ZXing.Net (versi 0.16.11) untuk membuat gambar barcode/QR secara offline:
      ```powershell
      Install-Package ZXing.Net
      ```
4.	Mengonfigurasi file “App.config” untuk mendaftarkan database connection string menuju basis data SQL Server Express LocalDB (`StockBridgeDB`).
5.	Membuat kelas-kelas model data (`User.cs`, `Product.cs`, `Category.cs`, `Request.cs`, `StockLog.cs`, `Unit.cs`) yang merepresentasikan kolom tabel relasional database.
6.	Membuat kelas pembantu `DatabaseHelper.cs` untuk mengelola inisialisasi awal database, deteksi otomatis keberadaan database `StockBridgeDB`, dan pembuatan tabel relasional secara otomatis (self-healing database).
7.	Membuat kelas-kelas repository terpisah ([UserRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/UserRepository.cs), [ProductRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/ProductRepository.cs), [RequestRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/RequestRepository.cs), dan [UnitRepository.cs](file:///c:/Users/grady/Downloads/StockBridge_XAML/StockBridge_XAML/UnitRepository.cs)) untuk membungkus perintah SQL Dapper agar memisahkan logika kueri SQL dari kode antarmuka.
8.	Menulis template visual kontrol WPF (“Styles” dan “ControlTemplates”) di file `ModernTheme.xaml` untuk mendesain tombol rounded, custom textbox, scrollbar, dan window borderless transparan.
9.	Merancang halaman `MainWindow.xaml` sebagai antarmuka Form Login utama dengan tampilan centered card layout dan validasi data masukan.
10.	Merancang antarmuka `DashboardWindow.xaml` yang mengimplementasikan split-pane layout dengan sidebar navigasi di sisi kiri dan area dinamis `Frame` di sisi kanan.
11.	Menulis logika otorisasi berbasis peran (Role-Based Access Control) di file code-behind `DashboardWindow.xaml.cs` untuk mengatur visibilitas tombol navigasi sesuai hak akses peran pengguna (Admin, Manager, Staff).
12.	Merancang antarmuka halaman `InventoryPage.xaml` dan code-behind untuk menampilkan daftar inventaris barang pada DataGrid, pencarian interaktif, serta tombol aksi.
13.	Merancang jendela modal pop-up `AddProductWindow.xaml` untuk menambahkan SKU produk baru lengkap dengan pilihan kategori, stok awal, serta area konversi satuan.
14.	Merancang jendela modal pop-up `UpdateStockWindow.xaml` (Adjust Stock) untuk memproses penyesuaian barang masuk atau keluar dengan pilihan konversi satuan eceran (Unit) atau grosir (Pack).
15.	Merancang halaman `UomPage.xaml` untuk mengelola master data satuan (Unit of Measurement) beserta proteksi referensi database agar satuan yang aktif digunakan tidak dapat dihapus.
16.	Merancang halaman `RequestPage.xaml` dan `NewRequestWindow.xaml` untuk alur pengajuan pasokan barang baru yang dibuat oleh peran Staff.
17.	Menulis logika verifikasi persetujuan (approval) permintaan pasokan pada `RequestPage.xaml.cs` yang hanya dapat diakses oleh Admin atau Manager, yang secara otomatis akan menambah stok produk di database saat disetujui.
18.	Merancang halaman `LogsPage.xaml` untuk menampilkan tabel riwayat log audit (audit trail) pergerakan stok masuk dan keluar secara kronologis.
19.	Mengimplementasikan server socket asinkron menggunakan `HttpListener` di kelas `NetworkHelper.cs` pada port 8080 untuk mendengarkan HTTP Request dari browser mobile.
20.	Merancang jendela dialog `ConnectMobileWindow.xaml` untuk menampilkan QR Code berisi alamat IP server lokal guna mempermudah sinkronisasi scanner mobile.
21.	Melakukan pengujian fungsionalitas menyeluruh (black-box testing) pada seluruh modul antarmuka, transaksi database, logika konversi, dan sinkronisasi mobile.
22.	Memperbaiki kesalahan, bug, atau kendala tata letak responsif WPF yang ditemukan selama tahap pengujian sistem.
23.	Menyusun dokumentasi akhir tugas proyek dan panduan praktis (Manual Book) penggunaan aplikasi StockBridge.

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
Tampilan akhir program merupakan hasil implementasi antarmuka (User Interface) aplikasi StockBridge yang telah berhasil dibangun dan diintegrasikan dengan database SQL Server. Bagian ini menyajikan gambaran visual dari setiap halaman utama:

1.	Tampilan Form Login
 
Gambar 2.20 Tampilan Form Login
Halaman masuk aplikasi (login screen) dirancang dengan konsep centered card layout yang memiliki efek drop shadow modern. Antarmuka ini memuat kotak dialog putih di atas latar belakang abu-abu terang, dihiasi inisial logo 'SB' dan teks judul aplikasi. Form ini dilengkapi dengan input TextBox untuk Username, PasswordBox dengan fitur toggle show/hide password (ikon mata) untuk kemudahan pengetikan, tombol utama 'SIGN IN' dengan warna gelap elegan, serta tombol sekunder 'KELUAR APLIKASI' berwarna merah marun.

2.	Tampilan Dashboard Navigasi Sidebar (Admin)
 
Gambar 2.21 Tampilan Dashboard Navigasi Sidebar (Admin)
Tampilan dashboard utama setelah Admin berhasil login. Antarmuka menggunakan desain split-pane, di mana panel sebelah kiri (sidebar) berwarna deep navy memuat inisial pengguna aktif, teks peranan 'Admin', dan daftar menu navigasi lengkap (Inventory, Request, Logs, Users, UoM). Area sebelah kanan merupakan Frame dinamis yang memuat konten halaman aktif secara responsif, lengkap dengan tombol window management (Minimize, Maximize, Close) di sudut kanan atas.

3.	Tampilan Halaman Inventaris Barang
 
Gambar 2.22 Tampilan Halaman Inventaris Barang
Halaman daftar inventaris barang (Inventory Page) menyajikan visualisasi tabel data (DataGrid) yang modern dan bersih. Kolom tabel menampilkan nomor urut, Kode SKU/ID produk, Nama Produk, jumlah stok aktif yang dihiasi badge hijau cerah, tanggal pembaruan terakhir, serta catatan deskripsi produk. Halaman ini juga dilengkapi tombol pencarian interaktif di bagian atas, tombol '+ Add New SKU' untuk mendaftarkan barang baru, tombol '⚙ Adjust Stock' untuk stok opname cepat, dan tombol 'Print Label' untuk mencetak QR Code.

4.	Tampilan Halaman Log Audit (Logs)
 
Gambar 2.23 Tampilan Halaman Log Audit
Halaman Log Audit (Logs Page) menampilkan catatan riwayat aktivitas mutasi persediaan barang secara kronologis (audit trail). Setiap record log memuat informasi waktu transaksi secara detail, ID produk, tipe transaksi (stok masuk dengan tanda '▲ STOCK IN' berwarna hijau atau stok keluar dengan tanda '▼ STOCK OUT' berwarna merah), jumlah kuantitas yang ditambahkan/dikurangi, serta total saldo stok akhir. Fitur ini sangat penting untuk pengawasan internal dan mencegah kehilangan barang.

5.	Tampilan Halaman Manajemen User (Team Access)
 
Gambar 2.24 Tampilan Halaman Manajemen User
Halaman Manajemen User (Users Page) yang khusus diakses oleh Admin untuk mengatur hak akses tim gudang. Di sebelah kiri terdapat form input pembuatan user baru yang meliputi kolom Username, Password, dan pilihan Peran (Admin, Manager, Staff). Di sebelah kanan terdapat DataGrid yang menampilkan daftar pengguna aktif sistem lengkap dengan badge peranan masing-masing (misalnya badge biru untuk Admin, badge ungu untuk Manager, dan badge abu-abu untuk Staff).

6.	Tampilan Halaman Manajemen Satuan (UoM)
 
Gambar 2.25 Tampilan Halaman Manajemen Satuan (UoM)
Halaman Manajemen Satuan (UoM Page) berfungsi untuk mengelola master data satuan pengukuran (Unit of Measurement). Antarmuka terbagi menjadi dua bagian: form input untuk memasukkan kode satuan (contoh: Pcs, Dus, Kg) beserta nama lengkapnya di sisi kiri, dan tabel daftar satuan aktif di sisi kanan. Sistem ini dilengkapi dengan Foreign Key constraints protector, sehingga jika suatu kode satuan sedang digunakan oleh salah satu produk di inventaris, tombol Hapus akan diblokir demi keamanan integritas database.

7.	Tampilan Form Tambah Barang Baru
 
Gambar 2.26 Tampilan Form Tambah Barang Baru
Jendela modal pop-up 'Add Product Window' yang muncul di tengah layar saat mendaftarkan produk baru. Form ini memiliki input Kode SKU, Nama Barang, Harga Beli, Pilihan Kategori, dan jumlah Stok Awal. Fitur unggulannya adalah penentuan konversi satuan di bagian bawah, di mana pengguna dapat memilih satuan terkecil (Unit), satuan kemasan besar (Pack), dan rate konversi (misal: 1 Dus berisi 24 Pcs), lengkap dengan teks kalkulasi dinamis yang berubah secara real-time saat data diketik.

8.	Tampilan Jendela Penyesuaian Stok (Adjust Stock)
 
Gambar 2.27 Tampilan Form Penyesuaian Stok (Adjust Stock)
Kotak dialog modal untuk melakukan penyesuaian stok fisik (Adjust Stock Window). Di dalam form ini, pengguna dapat memilih Tipe Transaksi (Barang Masuk atau Barang Keluar), memilih Satuan yang disesuaikan (Unit eceran atau Pack kemasan besar), dan memasukkan jumlah kuantitas. Jika memilih Pack, program secara otomatis mengalikan kuantitas input dengan rate konversi produk tersebut saat disimpan ke database SQL Server.

9.	Tampilan Form Permintaan Pasokan (New Request)
 
Gambar 2.28 Tampilan Form Permintaan Pasokan (New Request)
Jendela modal 'New Request Window' yang dapat diakses oleh peran Staff untuk mengajukan pengadaan stok barang baru dari supplier. Formulir ini dirancang sederhana dengan kolom input Nama Barang dan Jumlah Kuantitas yang dibutuhkan. Data yang disimpan akan langsung masuk ke database dengan status 'Pending' untuk menunggu proses peninjauan dan persetujuan dari Manager atau Admin.

10.	Tampilan QR Label Print Preview
 
Gambar 2.29 Tampilan QR Label Print Preview
Halaman pracetak stiker label barang (Print Preview Window) sebelum dicetak secara fisik ke printer. Jendela ini menampilkan visualisasi tata letak stiker label yang rapi, memuat gambar QR Code yang dihasilkan secara dinamis berdasarkan Kode SKU produk, nama produk di bagian bawah, dan tombol aksi 'Print' di pojok kanan atas untuk mengirim perintah cetak ke perangkat keras pencetak label.

11.	Tampilan Jendela Hubungkan Mobile (Connect Mobile)
 
Gambar 2.30 Tampilan Jendela Hubungkan Mobile
Jendela dialog modal 'Connect Mobile Window' yang digunakan untuk menghubungkan smartphone sebagai scanner barcode nirkabel. Jendela ini menampilkan gambar QR Code berukuran besar yang berisi URL tautan server lokal asinkron aplikasi (contoh: `http://192.168.1.15:8080/`). Pengguna cukup memindai QR Code ini menggunakan kamera smartphone untuk menyambungkan web scanner mobile secara instan tanpa ribet.

E.	Manual Book (Cara Penggunaan)
Manual book ini dibuat untuk memandu pengguna dalam mengoperasikan aplikasi StockBridge sesuai dengan hak akses (Role) masing-masing.

1.	Cara Login
1.	Buka aplikasi StockBridge dengan menjalankan file `StockBridge_XAML.exe`.
2.	Sistem akan memvalidasi koneksi database. Jika dijalankan pertama kali, basis data `StockBridgeDB` dan seluruh tabel relasional akan dibuat secara otomatis (self-healing database).
3.	Masukkan Username (contoh: `admin`, `manager`, atau `staff`) pada kolom input Username.
4.	Masukkan Password default (yaitu `admin123`, `manager123`, atau `staff123`) pada kolom input Password. Gunakan ikon mata di sebelah kanan jika ingin melihat teks password.
5.	Klik tombol "SIGN IN". Jika autentikasi sukses, program akan memuat dashboard utama sesuai dengan peranan hak akses pengguna.

2.	Cara Menggunakan Dashboard Admin
1.	Masuk sebagai pengguna dengan peran Admin.
2.	Setelah berhasil masuk, sistem akan menampilkan halaman Dashboard Utama Admin.
3.	Pada dashboard admin, seluruh menu sidebar kiri akan ditampilkan secara penuh, yaitu: Inventory, Request, Logs, Connect Mobile, Users, dan UoM.
4.	Admin dapat memindahkan halaman kerja dengan menekan tombol menu pada sidebar tersebut.

3.	Cara Menggunakan Dashboard Manager
1.	Masuk sebagai pengguna dengan peran Manager.
2.	Setelah berhasil masuk, sistem menampilkan Dashboard Manager yang dirancang khusus untuk pengawasan gudang.
3.	Sistem secara otomatis menyembunyikan menu Users (Manajemen Anggota Tim) dan menu UoM (Master Data Satuan) pada sidebar untuk menjaga keamanan konfigurasi.
4.	Manager hanya memiliki akses ke menu utama Inventory, Request (untuk memproses persetujuan stok), dan Logs (riwayat audit).

4.	Cara Menggunakan Dashboard Staff
1.	Masuk sebagai pengguna dengan peran Staff.
2.	Setelah berhasil masuk, sistem menampilkan Dashboard Staff dengan hak akses operasional terbatas.
3.	Sidebar hanya akan menampilkan menu: Inventory (untuk melihat persediaan dan melakukan stok opname mandiri) dan Request (untuk mengajukan pasokan barang baru).
4.	Menu pengelolaan data master (Users, UoM) dan log audit transaksi (Logs) sepenuhnya disembunyikan dari antarmuka Staff.

5.	Cara Mengelola Data Barang / SKU
1.	Buka menu "Inventory" pada sidebar kiri.
2.	Klik tombol "+ Add New SKU" di bagian kanan atas DataGrid untuk menampilkan formulir tambah produk.
3.	Masukkan Kode Barang (SKU), Nama Produk, Kategori, Harga Beli, dan Jumlah Stok Awal.
4.	Di bagian "Konversi Satuan", pilih tipe Satuan Unit (eceran), Satuan Pack (kemasan besar), dan tentukan Rate Konversi (pengali kuantitas).
5.	Perhatikan label "Hasil Konversi" yang berubah secara dinamis (misal: "Hasil Konversi: 1 Dus = 24 Pcs") untuk memverifikasi akurasi input.
6.	Klik tombol "SIMPAN". Produk baru akan disimpan ke SQL Server, serta file QR Code dan Barcode akan digenerate otomatis secara offline.

6.	Cara Melakukan Penyesuaian Stok (Adjust Stock)
1.	Buka menu "Inventory" pada sidebar.
2.	Pilih salah satu baris produk pada DataGrid yang ingin disesuaikan stoknya.
3.	Klik tombol "⚙ Adjust Stock" di bagian menu atas tabel.
4.	Pilih Tipe Transaksi: "Barang Masuk" (stok bertambah) atau "Barang Keluar" (stok berkurang).
5.	Pilih Satuan input yang ingin digunakan: "Unit" atau "Pack". Jika memilih Pack, kuantitas yang dimasukkan akan dikalikan dengan rate konversi produk secara otomatis.
6.	Masukkan jumlah kuantitas penyesuaian pada kolom Quantity.
7.	Klik tombol "SIMPAN PERUBAHAN". Stok barang di database akan ter-update dan riwayat perubahan tercatat di halaman Logs.

7.	Cara Mengelola Master Data Satuan (UoM)
1.	Buka menu "UoM" pada sidebar (khusus Admin).
2.	Untuk menambah data: Masukkan Kode Satuan (contoh: `Rim`) dan Nama Satuan (contoh: `Rim Kertas`) pada kotak input.
3.	Klik tombol "SIMPAN" untuk mendaftarkannya ke database.
4.	Untuk menghapus: Pilih baris satuan pada DataGrid lalu klik tombol "Hapus". Sistem memiliki pengaman integritas data (Foreign Key constraint), sehingga satuan yang sedang aktif digunakan oleh produk tidak dapat dihapus secara tidak sengaja.

8.	Cara Mengelola Anggota Tim / User
1.	Buka menu "Users" pada sidebar (khusus Admin).
2.	Untuk menambah pengguna baru: Isi kolom Username, Password, dan pilih Peran aksesnya (Admin, Manager, Staff).
3.	Klik tombol "SIMPAN". Sandi pengguna secara otomatis dienkripsi dengan hash SHA-256 demi keamanan database.
4.	Untuk memperbarui atau menghapus: Pilih data user pada tabel DataGrid lalu gunakan tombol "Ubah" atau "Hapus".

9.	Cara Mengajukan Permintaan Pasokan Barang
1.	Login sebagai Staff, lalu buka menu "Request" pada sidebar.
2.	Klik tombol "+ New Request" di bagian atas tabel.
3.	Masukkan Nama Barang yang ingin diajukan beserta jumlah kuantitas yang dibutuhkan.
4.	Klik tombol "SIMPAN" untuk mengirimkan permohonan. Permintaan akan terdaftar pada tabel dengan status awal "Pending".

10.	Cara Menyetujui atau Menolak Permintaan Pasokan
1.	Login sebagai Manager atau Admin, lalu buka menu "Request" pada sidebar.
2.	Pilih baris pengajuan permintaan pasokan yang berstatus "Pending" pada tabel.
3.	Untuk menyetujui: Klik tombol "Approve Supply". Sistem akan menambahkan kuantitas barang yang diminta ke dalam tabel produk di database secara otomatis (melalui query Dapper) dan mengubah status menjadi "Approved".
4.	Untuk menolak: Klik tombol "Decline Request". Status pengajuan akan berubah menjadi "Rejected" dan tidak ada penambahan stok barang di database.

11.	Cara Menghubungkan Mobile Scanner (Connect Mobile)
1.	Buka menu "Connect Mobile" pada sidebar dashboard.
2.	Sistem akan menampilkan jendela modal dialog berisi gambar QR Code koneksi.
3.	Ambil smartphone yang terhubung dalam satu jaringan Wi-Fi lokal yang sama dengan laptop.
4.	Pindai QR Code tersebut menggunakan kamera smartphone. Smartphone akan membuka link browser yang terhubung ke IP server lokal laptop pada port 8080 (contoh: `http://192.168.1.15:8080/`).
5.	Smartphone siap digunakan sebagai alat pemindai barcode kamera nirkabel secara real-time tanpa memerlukan konfigurasi flags.

12.	Cara Mencetak Label QR Code Barang
1.	Buka menu "Inventory" pada sidebar, lalu klik baris produk yang diinginkan.
2.	Klik tombol "Print Label" di bagian atas DataGrid.
3.	Sistem akan membuka jendela modal pracetak (*Print Preview*) yang menyajikan tata letak visual label stiker QR Code dan nama produk.
4.	Klik tombol "Print" untuk mencetak stiker label tersebut menggunakan mesin pencetak yang terhubung.

13.	Cara Logout
1.	Klik tombol "Logout" yang terletak di bagian bawah sidebar navigasi.
2.	Sistem secara otomatis akan menutup sesi pengguna aktif, mengosongkan token peran, dan mengarahkan tampilan kembali ke halaman Form Login utama.

BAB III
A.	Kesimpulan
Berdasarkan proses perancangan, pengembangan, dan pengujian yang telah dilaksanakan pada Aplikasi Manajemen Logistik (StockBridge), dapat ditarik beberapa kesimpulan penting sebagai berikut:
1.	Integrasi Sistem dan Pembagian Peran (Role-Based Access Control):
	Penerapan pembagian hak akses pengguna menjadi tiga peran (Admin, Manager, dan Staff) terbukti krusial dalam menjaga kerahasiaan dan integritas data gudang. Sistem ini memastikan bahwa data master sensitif hanya dapat dikelola oleh Admin, verifikasi dan approval transaksi hanya dilakukan oleh Manager, sedangkan aktivitas operasional harian dapat dikerjakan oleh Staff. Hal ini meminimalisir penyalahgunaan wewenang dan menjaga stabilitas data inventaris.
2.	Efisiensi Operasional dengan Teknologi QR Code dan Pemindaian Mobile:
	Integrasi library ZXing.Net untuk men-generate label QR Code dan Barcode secara offline mempercepat proses identifikasi produk secara signifikan. Ditambah dengan fitur Connect Mobile yang memanfaatkan HttpListener lokal asinkron, smartphone dapat berfungsi sebagai barcode scanner tanpa harus mengatur konfigurasi perizinan jaringan yang rumit. Solusi nirkabel ini terbukti meningkatkan kecepatan proses stok opname dan meminimalisir kesalahan pencatatan (human error) dibandingkan penulisan manual.
3.	Transparansi dan Akuntabilitas Melalui Riwayat Aktivitas (Audit Trail):
	Pencatatan otomatis setiap pergerakan barang masuk dan keluar ke dalam tabel stock_logs (audit trail) memberikan riwayat yang jelas dan dapat dilacak. Setiap data log menyertakan identitas pengguna yang melakukan perubahan, tipe transaksi, kuantitas, serta waktu kejadian. Hal ini memberikan transparansi penuh bagi manajemen untuk melakukan audit internal persediaan barang sewaktu-waktu tanpa hambatan.
4.	Keandalan dan Kemudahan Pemeliharaan dengan Arsitektur WPF dan Dapper:
	Pengembangan antarmuka menggunakan Windows Presentation Foundation (WPF) dengan Styles terpusat menghasilkan UI yang bersih, modern, dan sangat responsif. Penggunaan SQL Server LocalDB dikombinasikan dengan micro-ORM Dapper memisahkan logika query SQL dari UI code-behind (melalui repository pattern), menghasilkan performa aplikasi desktop yang sangat cepat, ringan dijalankan, dan mudah dipelihara di masa depan.


B.	Saran
Meskipun aplikasi StockBridge telah berfungsi dengan baik dan memenuhi indikator keberhasilan, penulis menyadari masih terdapat ruang peningkatan untuk pengembangan lebih lanjut. Beberapa saran yang diusulkan antara lain:
1.	Penerapan Sistem Hashing Password Secara Menyeluruh:
	Meskipun sistem telah menggunakan verifikasi kredensial dasar, untuk pengembangan masa depan disarankan mengimplementasikan hashing yang lebih kuat (seperti BCrypt atau Argon2) pada tabel database users guna mengantisipasi kebocoran data jika file database lokal diakses pihak ketiga secara ilegal.
2.	Ekspansi Entitas Database untuk Kebutuhan Multi-Gudang:
	Menambahkan tabel master data seperti Supplier (pemasok barang) dan Location (multi-gudang) akan membuat aplikasi StockBridge menjadi lebih fleksibel dan dapat diterapkan pada skenario bisnis yang lebih besar dengan banyak cabang distribusi barang.
3.	Pengembangan Fitur Pelaporan dan Dashboard Analitis:
	Menyediakan grafik tren barang masuk/keluar secara bulanan serta fitur ekspor laporan resmi otomatis ke format Microsoft Excel (.xlsx) atau PDF (.pdf) akan sangat mempermudah Manager dalam menganalisis perputaran inventaris dan membuat keputusan pengadaan stok.
4.	Sistem Peringatan Stok Minimum (Alert Threshold Notification):
	Mengimplementasikan sistem notifikasi otomatis atau peringatan visual (alert) ketika kuantitas stok barang tertentu mendekati atau berada di bawah ambang batas minimal (safety stock) agar tim operasional dapat segera mengajukan permintaan pasokan sebelum persediaan habis.

 
DAFTAR PUSTAKA

Dapper. 2026. Dapper Micro-ORM Tutorial and Documentation. Diakses dari https://dapper-tutorial.net/

NuGet. 2026. ZXing.Net. Diakses dari https://www.nuget.org/packages/ZXing.Net

Microsoft. 2025. Introduction to WPF (Windows Presentation Foundation). Microsoft Learn. Diakses dari https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/

Microsoft. 2025. Object-Oriented Programming (C#). Microsoft Learn. Diakses dari https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
    
Microsoft. 2026. SQL Server Express LocalDB. Microsoft Learn. Diakses dari https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb

Rosa A.S. dan M. Shalahuddin. 2018. Rekayasa Perangkat Lunak Terstruktur dan Berorientasi Objek. Bandung: Informatika.

Sutabri, Tata. 2012. Analisis Sistem Informasi. Yogyakarta: Andi.
