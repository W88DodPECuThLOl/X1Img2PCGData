# X1Img2PCGData
This tool converts image data into PCG data for X1.

# これは何？

X1というパソコンのPCGデータを作成するツールです。

# 使い方


> X1Img2PCGData 画像ファイル名 [文字定義ファイル名 [出力ファイル名]]


| パラメータ | 説明 |
|---|---|
| 画像ファイル名 | PCGの元となる画像ファイル名を指定します。<br>画像はPNG形式を推奨します。 |
| 文字定義ファイル名 | 画像中の文字の配置を定義したテキストファイルを指定します。<br>省略した場合は、画像ファイル名の拡張子をtxtにしたものが使われます。 |
| 出力ファイル名 | 出力するPCGデータのファイル名を指定します。<br>省略した場合は、画像ファイル名の拡張子をDATにしたものが使われます。 |

## 文字定義ファイルについて

画像ファイルとPCGの文字の対応を定義しているテキストファイルです。  
X1のPCGは1文字8x8ドットで定義されています。これを画像のどこから拾ってくるのかを定義します。

文字定義ファイルの１文字が定義するPCGと対応しており、改行することで8ドット下に移動します。  
画像ファイルと対応するようにテキストを記述します。

例えば、![Sample Image](/sample/PCGDATA.png)のような画像ファイルの文字定義ファイルは、下記のようになるでしょう。
```
 ABCDEFG  
HIJKLMNO  
PQRSTUVW  
XYZ'.,!   
01234567  
89-
```

## 出力ファイルについて

バイナリ形式のファイルとなります。  
最初にPCGの定義数が１バイト。  
次に「1バイトの文字コードとPCGのパターンデータ」がPCGの定義数分繰り返されます。  
PCGのパターンデータ部分は、Bプレーン、Rプレーン、Gプレーンの順で、各8バイトの計24バイトのデータとなります。

# PCGを定義するには？

sdcc用のサンプルがありますので、それを参考に実装してみてください。  
[PCGを定義するサンプル](/sample/asm_x1pcg.asm)
