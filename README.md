# かんたん大島 / EasyOjima
（制作途中）大島テクニック作成支援ソフト

## Q. これなに
\>\> 大島テクニックを楽に作れるようになっちゃうソフトです。

詳しくは[**こちら**](https://www.kankantari.net/EasyOjima) （リンク先はまだない）

## 使い方
< 解説動画を作成中… >

## ダウンロード

### 利用規約
* このアプリはフリーウェアです。個人利用、商用利用を問わず無料で使用できます。
* このアプリの改変・改良は、利用者が自由に行うことができます。ただし、改変・改良により発生する不具合は、利用者が責任を負います。
* トラブル防止のため、オリジナルのもの、改変したものを問わずアプリの再頒布、並びに第三者から利益を得ることを禁止します。
* このアプリに起因するいかなる損害について、アプリ製作者は一切の責任を負いません。
* <strong>強制ではないですが、このアプリを使って制作した作品をインターネット上に公開する際には、このWebページのリンクを貼っていただけると嬉しいです。</strong>

## プラグイン開発
需要なさそう()

<strong>このリポジトリのファイルだけで作ることは可能ですが、準備が面倒な方は`@Nodoka_Oto_Mad`(twiter)または`Nodoka#7342`(Discord)までDMください。テンプレートを押し付けます。</strong>

### つくりかた
1. このリポジトリをローカルにクローン。
2. `Resource`という名前でリソースを作り、`IMAGE_EASINGS`という名前の画像、`BUGREPORT_WEBHOOK`と`REQUEST_WEBHOOK`という名前の文字列を追加（適当でOK）。
3. 同じソリューションに、好きな名前でプロジェクトを追加。
4. `<プロジェクト名>.csproj`を以下のように編集。
```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\EasyOjima\EasyOjima.csproj" />
  </ItemGroup>

</Project>
```
5. `PluginMain.cs`（名前はなんでもOK）を追加して、以下のように編集。
```csharp
using EasyOjima.Plugin;

namespace プラグイン名 {
    class PluginMain : IPlugin {
        public string Name => "表示させたいプラグイン名";
        public string Description => "プラグインの説明";
        public string Author => "作者";
        public PluginHost Host { get; set; }
    
        // プラグインのエントリポイント
        public void Run() {
        // 処理
        }
    }
}
```
6. ビルド

出力された`<プロジェクト名>.dll`（外部ライブラリを使った場合、それらのdllも）をかんたん大島のpluginsフォルダに入れると、読み込まれるはずです。

### PluginHostについて
< 工事中 >
### イベントについて
< 工事中 >
