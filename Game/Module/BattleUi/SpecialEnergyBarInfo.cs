using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F88 RID: 24456
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarInfo
	{
		// Token: 0x0603D684 RID: 251524 RVA: 0x00F9F5B0 File Offset: 0x00F9D7B0
		public unsafe void Init(int id, SSpecialEnergyBar config)
		{
			this.Id = id;
			this.PrefabType = (int)config.PrefabType;
			this.ExtraType = config.ExtraType;
			this.SlotNum = config.SlotNum;
			this.InitExtraParams<float>(config.ExtraFloatParams, this.ExtraFloatParams);
			this.PrefabPath = config.PrefabPath.ToAssetPathName();
			this.AttributeId = config.AttributeId;
			this.MaxAttributeId = config.MaxAttributeId;
			this.BuffId = config.BuffId;
			this.TagEnergyBarIdMap = this.ParseGameplayAnySimple<int>(config.TagEnergyBarIdMap);
			if (!string.IsNullOrEmpty(config.EffectColor))
			{
				string[] array = config.EffectColor.Split('#', StringSplitOptions.None);
				this.EffectColor = array[0];
				this.OtherEffectColorList = new List<string>(RuntimeHelpers.GetSubArray<string>(array, Range.StartAt(1)));
			}
			else
			{
				this.EffectColor = null;
			}
			if (!string.IsNullOrEmpty(config.PointColor))
			{
				string[] array2 = config.PointColor.Split('#', StringSplitOptions.None);
				this.PointColor = array2[0];
				this.PointColorList = array2;
			}
			else
			{
				this.PointColor = null;
			}
			this.IconPath = config.TexturePath.ToAssetPathName();
			this.EnableIconPath = config.EnableTexturePath.ToAssetPathName();
			this.FrontIconPath = config.FrontTexturePath.ToAssetPathName();
			this.InitPathList(config.NiagaraList, this.NiagaraPathList);
			this.KeyEnableNiagaraIndex = config.KeyEnableNiagaraIndex;
			if (this.KeyEnableNiagaraIndex >= this.NiagaraPathList.Count)
			{
				this.KeyEnableNiagaraIndex = -1;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "能量条配置错误, 可用时粒子特效索引超出粒子数组长度";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", config.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("索引", this.KeyEnableNiagaraIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("数组长度", this.NiagaraPathList.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			this.KeyType = config.KeyType;
			this.DisableKeyOnPercent = (float)config.DisableKeyOnPercent / 100f;
			if (config.KeyEnableTag.TagName != FName.NAME_None)
			{
				this.KeyEnableTagId = config.KeyEnableTag.TagId();
			}
			else
			{
				this.KeyEnableTagId = 0;
			}
			this.InitKeyInfo(config.KeyInfoList);
		}

		// Token: 0x0603D685 RID: 251525 RVA: 0x00F9F818 File Offset: 0x00F9DA18
		private void InitKeyInfo(TArray<SSpecialEnergyBarKey> keyInfoList)
		{
			int num = keyInfoList.Num();
			for (int i = 0; i < num; i++)
			{
				SSpecialEnergyBarKey sspecialEnergyBarKey = keyInfoList.Get(i);
				SpecialEnergyBarKeyInfo item = new SpecialEnergyBarKeyInfo
				{
					Action = sspecialEnergyBarKey.Action,
					ActionType = sspecialEnergyBarKey.ActionType
				};
				this.KeyInfoList.Add(item);
			}
		}

		// Token: 0x0603D686 RID: 251526 RVA: 0x00F9F86C File Offset: 0x00F9DA6C
		private Dictionary<int, T> ParseGameplayAnySimple<[Nullable(2)] T>(TMap<FGameplayTag, T> map)
		{
			int num = map.Num();
			Dictionary<int, T> dictionary = new Dictionary<int, T>(num);
			if (num <= 0)
			{
				return dictionary;
			}
			foreach (KeyValuePair<FGameplayTag, T> keyValuePair in map)
			{
				FGameplayTag fgameplayTag;
				T t;
				keyValuePair.Deconstruct(out fgameplayTag, out t);
				FGameplayTag tag = fgameplayTag;
				T value = t;
				dictionary[tag.TagId()] = value;
			}
			return dictionary;
		}

		// Token: 0x0603D687 RID: 251527 RVA: 0x00F9F8E0 File Offset: 0x00F9DAE0
		private void InitExtraParams<[Nullable(2)] T>(TArray<T> srcArray, List<T> destArray)
		{
			int num = srcArray.Num();
			if (num <= 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				T item = srcArray.Get(i);
				destArray.Add(item);
			}
		}

		// Token: 0x0603D688 RID: 251528 RVA: 0x00F9F914 File Offset: 0x00F9DB14
		private void InitPathList(TArray<TSoftObjectPtr<UNiagaraSystem>> srcArray, List<string> destArray)
		{
			int num = srcArray.Num();
			if (num <= 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				TSoftObjectPtr<UNiagaraSystem> tsoftObjectPtr = srcArray.Get(i);
				destArray.Add(tsoftObjectPtr.ToAssetPathName());
			}
		}

		// Token: 0x04022802 RID: 141314
		public int Id;

		// Token: 0x04022803 RID: 141315
		public int PrefabType;

		// Token: 0x04022804 RID: 141316
		public int ExtraType;

		// Token: 0x04022805 RID: 141317
		public int SlotNum;

		// Token: 0x04022806 RID: 141318
		public List<float> ExtraFloatParams = new List<float>();

		// Token: 0x04022807 RID: 141319
		public string PrefabPath = string.Empty;

		// Token: 0x04022808 RID: 141320
		public int AttributeId;

		// Token: 0x04022809 RID: 141321
		public int MaxAttributeId;

		// Token: 0x0402280A RID: 141322
		public long BuffId;

		// Token: 0x0402280B RID: 141323
		public int KeyEnableTagId;

		// Token: 0x0402280C RID: 141324
		[Nullable(2)]
		public Dictionary<int, int> TagEnergyBarIdMap;

		// Token: 0x0402280D RID: 141325
		[Nullable(2)]
		public string EffectColor;

		// Token: 0x0402280E RID: 141326
		public List<string> OtherEffectColorList = new List<string>();

		// Token: 0x0402280F RID: 141327
		[Nullable(2)]
		public string PointColor;

		// Token: 0x04022810 RID: 141328
		public string[] PointColorList = Array.Empty<string>();

		// Token: 0x04022811 RID: 141329
		[Nullable(2)]
		public string IconPath;

		// Token: 0x04022812 RID: 141330
		[Nullable(2)]
		public string EnableIconPath;

		// Token: 0x04022813 RID: 141331
		[Nullable(2)]
		public string FrontIconPath;

		// Token: 0x04022814 RID: 141332
		public List<string> NiagaraPathList = new List<string>();

		// Token: 0x04022815 RID: 141333
		public int KeyEnableNiagaraIndex;

		// Token: 0x04022816 RID: 141334
		public int KeyType;

		// Token: 0x04022817 RID: 141335
		public float DisableKeyOnPercent;

		// Token: 0x04022818 RID: 141336
		public List<SpecialEnergyBarKeyInfo> KeyInfoList = new List<SpecialEnergyBarKeyInfo>();
	}
}
