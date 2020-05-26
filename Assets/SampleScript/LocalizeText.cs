using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using CoffeeR.Translate;

public class LocalizeText : Text
{
    [SerializeField, Header("翻訳テキストID")] int textId = 0;
    [SerializeField, Header("翻訳言語")] Language language = Language.Japanese;
    Translater translater;


    protected override void Start()
    {
        Addressables.LoadAssetAsync<TextAsset>("Assets/TranslateTable.csv").Completed += OnLoad;
    }


    private void OnLoad(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<TextAsset> handle)
    {
        var translateTextData = handle.Result;
        var translater = new Translater(translateTextData.text);
        this.text = translater.GetText(textId, Language.Japanese);
    }
}




