using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020034EC RID: 13548
[UnitTest]
public class LoadResourceTest : UnitTestBase
{
	// Token: 0x170026ED RID: 9965
	// (get) Token: 0x0601CA2D RID: 117293 RVA: 0x00896DE6 File Offset: 0x00894FE6
	[Nullable(1)]
	public override string Name
	{
		[NullableContext(1)]
		get
		{
			return "LoadResourceTest";
		}
	}

	// Token: 0x0601CA2E RID: 117294 RVA: 0x00896DF0 File Offset: 0x00894FF0
	public override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		string path2 = "/Game/Aki/Map/Level/Other/IOS_TEST/InstanceTree_ios_test";
		UWorld item = Singleton<ResourceSystem>.Instance.Load<UWorld>(path2, "js_undefined");
		string message = "同步加载Level";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", item);
		base.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		string text = "/Game/Aki/Data/Entity/CDT_ModelConfig.CDT_ModelConfig";
		string message2 = "异步加载DataTable(开始)";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", text);
		base.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		UniTaskCompletionSource<bool> tcs = new UniTaskCompletionSource<bool>();
		Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>(text, delegate([Nullable(2)] UDataTable asset, string path)
		{
			UnitTestBase <>4__this = this;
			string message3 = "异步加载DataTable(结束)";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("DataTableName", asset);
			<>4__this.Info(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			tcs.TrySetResult(asset != null);
		}, 100, "js_undefined");
		return tcs.Task;
	}
}
