# ARCastle  

## 概要  
### ARCore + NavMeshを組み合わせたサンプル

## 内容  
### 1. マーカー読み込み  
> マーカーとして設定した画像をカメラを通して読み込ませる  
> 画像を認識するまで端末を上下左右に動かして、いろいろな方向に向けてあげると画像を認識しやすい。  
![Screenshot1](https://user-images.githubusercontent.com/17695962/76208163-7778f200-6242-11ea-863c-4d2537b20ef4.PNG)  
  
### 2. オブジェクトの表示  
> マーカーの読み込みが成功すると、フィールドとキャラクタが表示されます。  
> 画面下に表示される扉をタッチすると、扉が開くので部屋に入る。  
![Screenshot2](https://user-images.githubusercontent.com/17695962/76208291-be66e780-6242-11ea-9456-66d093e22144.PNG)  
  
### 3. Unityちゃんが出迎えてくれます  
> 扉を開いたタイミングで、Unityちゃんが出入り口近くまで出迎えてくれます。  
> Unityちゃんをタッチするとアクションを起こしてくれます。  
![Screenshot3](https://user-images.githubusercontent.com/17695962/76208296-c030ab00-6242-11ea-9658-3e689a13990d.PNG)  
  
### 4. 以上  
> サンプルとしては以上です。  
> 暇になったらアップデートするかも？  
  
## 引用  
- キャラクタモデル  
["Unity-Chan!" Model](https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705)  

- ステージモデル  
[Low Poly Western Saloon](https://assetstore.unity.com/packages/3d/environments/low-poly-western-saloon-85578)  

- 動的にNavMeshを生成する  
[Unity:動的NavMeshの確認](https://simplestar-tech.hatenablog.com/entry/2019/01/05/193136)  

## 環境  
- Unity 2019.2.16f1
- ARCore 1.15.0
- VisualStudio 2019
- C#
  
### 動画  
- [実行動画(twitter)](https://twitter.com/RerykA99/status/1238100296053575681)  
