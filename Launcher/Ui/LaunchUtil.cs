using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui
{
	// Token: 0x020044F7 RID: 17655
	[NullableContext(1)]
	[Nullable(0)]
	public static class LaunchUtil
	{
		// Token: 0x0602E892 RID: 190610 RVA: 0x00B06A08 File Offset: 0x00B04C08
		public static Dictionary<string, string> GetDataTableMap([Nullable(2)] UDataTable table, string propertyValue)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (table == null)
			{
				return dictionary;
			}
			TArray<FName> tarray = new TArray<FName>();
			UDataTableFunctionLibrary.GetDataTableRowNames(table, ref tarray);
			TArray<string> dataTableColumnAsString = UDataTableFunctionLibrary.GetDataTableColumnAsString(table, new FName(propertyValue));
			for (int i = 0; i < tarray.Num(); i++)
			{
				string key = tarray.Get(i).ToString();
				string value = dataTableColumnAsString.Get(i);
				dictionary[key] = value;
			}
			return dictionary;
		}

		// Token: 0x0602E893 RID: 190611 RVA: 0x00B06A78 File Offset: 0x00B04C78
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static UniTask<AActor> LoadResourceAsync(string path, [Nullable(2)] UObject worldContextObject, [Nullable(2)] USceneComponent parent, Action<AActor> callback, string memoryTag = "js_call_launch")
		{
			LaunchUtil.<LoadResourceAsync>d__2 <LoadResourceAsync>d__;
			<LoadResourceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadResourceAsync>d__.path = path;
			<LoadResourceAsync>d__.worldContextObject = worldContextObject;
			<LoadResourceAsync>d__.parent = parent;
			<LoadResourceAsync>d__.callback = callback;
			<LoadResourceAsync>d__.memoryTag = memoryTag;
			<LoadResourceAsync>d__.<>1__state = -1;
			<LoadResourceAsync>d__.<>t__builder.Start<LaunchUtil.<LoadResourceAsync>d__2>(ref <LoadResourceAsync>d__);
			return <LoadResourceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E894 RID: 190612 RVA: 0x00B06ADC File Offset: 0x00B04CDC
		public static Dictionary<int, double> ObjToMap<[Nullable(0)] TKey, [Nullable(0)] TValue>(Dictionary<TKey, TValue> obj) where TKey : IConvertible where TValue : IConvertible
		{
			Dictionary<int, double> dictionary = new Dictionary<int, double>();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in obj)
			{
				int key = Convert.ToInt32(keyValuePair.Key);
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = Convert.ToDouble(keyValuePair.Value);
				}
			}
			return dictionary;
		}

		// Token: 0x0401A6FE RID: 108286
		public const string UiRootPath = "/Game/Aki/UI/Module/HotFix/Prefab/ScreenSpaceUIRoot.ScreenSpaceUIRoot";
	}
}
