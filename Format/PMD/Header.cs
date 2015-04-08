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
                //public string modelName;
                //public string comment;

                public byte optionalDataSize;
                public byte encodeType;
                public byte additionalUVNumber;
                public byte vertexIndexSize;

                public override void Read(System.IO.BinaryReader r)
                {
                    magic = ReadString(r, 4);//マジックナンバー、PMXの場合は4byteなので4
                    version = ReadFloat(r);//PMXのVer、たぶんここは一緒でいい気がする

                    optionalDataSize = ReadByte(r);
                    encodeType = ReadByte(r);
                    additionalUVNumber = ReadByte(r);
                    vertexindexSize = ReadByte(r);

                    //lengthbyte = Readbyte(r);//便宜的に追加的な、どこで呼び出せるかとかは考える
                    /*読んだときに、バイトを保存しておく。多態化・deform、バイナリは上から順に(?)読んでくれるらしいので、
                     * 呼び出し順番は意識しつつ、呼び出す手順とかはいらないっぽい（要は順番に読み込んでいけばおｋ）*/

                    modelName = ReadString(r, 20);//モデル情報、モデルの名前、英語にも対応可能・・・のはず
                    comment = ReadString(r, 256);//モデルのコメント、こちらも英語に対応可能
                }
            }
        }
    }
}