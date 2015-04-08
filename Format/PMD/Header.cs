using System.Collections;

namespace MMD
{
    namespace Format
    {
        namespace PMD
        {
            public class Header : Chunk
            {
                public string magic;
                public float version;
                //public byte lengthbyte;//バイト列を格納するための変数
                public string modelName;
                public string comment;

                public override void Read(System.IO.BinaryReader r)
                {
                    magic = ReadString(r, 3);//マジックナンバー、PMXの宣言、PMDと同じでいいか？
                    version = ReadFloat(r);//PMXのVer、たぶんここは一緒でいい気がする

                    //lengthbyte = Readbyte(r);//便宜的に追加的な、どこで呼び出せるかとかは考える

                    modelName = ReadString(r, 20);//モデル情報、モデルの名前、英語にも対応可能・・・のはず
                    comment = ReadString(r, 256);//モデルのコメント、こちらも英語に対応可能
                }
            }
        }
    }
}