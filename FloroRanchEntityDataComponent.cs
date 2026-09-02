using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.FloroRanch;

// Token: 0x02001BE3 RID: 7139
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchEntityDataComponent)]
public class FloroRanchEntityDataComponent : FloroRanchEntityDataBaseComponent
{
	// Token: 0x0600CFA5 RID: 53157 RVA: 0x00372384 File Offset: 0x00370584
	public override void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		this.EntityId = entityData.PlayIncId;
		this.EntityType = (EFloroRanchEntityType)entityData.Type;
		this.LastPoint = this.Point;
		this.Point = entityData.Point;
		this.ConfigId = entityData.Id;
		this.StartStage = entityData.StartStage;
		this.StartDay = entityData.StartDay;
		this.TagId = entityData.TagId;
		this.TagData.SetTagId(this.TagId);
		FRActionSelfDefineValue selfDefineValue = entityData.SelfDefineValue;
		if (selfDefineValue != null)
		{
			this.TagData.SetDynamicParams((int)Singleton<MathUtils>.Instance.LongToBigInt(selfDefineValue.N), (int)Singleton<MathUtils>.Instance.LongToBigInt(selfDefineValue.M), (int)Singleton<MathUtils>.Instance.LongToBigInt(selfDefineValue.P));
		}
		this.InitBuffList(entityData.BuffList.ToList<FloroRanchPlayBuff>());
		this.Count = entityData.Num;
		this.DailySaleData.SetAmount((int)Singleton<MathUtils>.Instance.LongToBigInt(entityData.Salary));
	}

	// Token: 0x0600CFA6 RID: 53158 RVA: 0x00372484 File Offset: 0x00370684
	private void InitBuffList(List<FloroRanchPlayBuff> buffList)
	{
		this.BuffMap.Clear();
		this.TipShowBuffList.Clear();
		this.EffectShowBuffList.Clear();
		foreach (FloroRanchPlayBuff buff in buffList)
		{
			FloroRanchBuffData floroRanchBuffData = new FloroRanchBuffData();
			floroRanchBuffData.RefreshBuffData(buff);
			this.BuffMap[floroRanchBuffData.GetInstanceId()] = floroRanchBuffData;
			this.AddBuffDataToShowList(floroRanchBuffData);
		}
	}

	// Token: 0x0600CFA7 RID: 53159 RVA: 0x00372514 File Offset: 0x00370714
	public void UpdateBuff(FRUnitOperateBuffAction buffAction)
	{
		if (buffAction.Type == FRBuffOperate.BuffOpAdd)
		{
			this.AddBuff(buffAction.Buff);
			return;
		}
		if (buffAction.Type == FRBuffOperate.BuffOpRemove)
		{
			this.RemoveBuff(buffAction.Buff);
			return;
		}
		this.RefreshBuff(buffAction.Buff);
	}

	// Token: 0x0600CFA8 RID: 53160 RVA: 0x00372550 File Offset: 0x00370750
	public unsafe void AddBuff(FloroRanchPlayBuff buff)
	{
		FloroRanchBuffData floroRanchBuffData;
		if (this.BuffMap.TryGetValue(buff.PlayIncId, out floroRanchBuffData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "Buff is already exist!";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", this.Info());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", floroRanchBuffData.GetConfigId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BuffInstanceId", floroRanchBuffData.GetInstanceId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("AddBuffInstanceId", buff.PlayIncId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		FloroRanchBuffData floroRanchBuffData2 = new FloroRanchBuffData();
		floroRanchBuffData2.RefreshBuffData(buff);
		this.BuffMap[floroRanchBuffData2.GetInstanceId()] = floroRanchBuffData2;
		this.AddBuffDataToShowList(floroRanchBuffData2);
	}

	// Token: 0x0600CFA9 RID: 53161 RVA: 0x00372648 File Offset: 0x00370848
	public unsafe void RemoveBuff(FloroRanchPlayBuff buff)
	{
		FloroRanchBuffData floroRanchBuffData;
		if (!this.BuffMap.TryGetValue(buff.PlayIncId, out floroRanchBuffData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "Buff is not exist!";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", this.Info());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", buff.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BuffInstanceId", buff.PlayIncId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		this.BuffMap.Remove(floroRanchBuffData.GetInstanceId());
		if (floroRanchBuffData.IsShowOnTip)
		{
			this.TipShowBuffList.RemoveAt(this.TipShowBuffList.IndexOf(floroRanchBuffData));
		}
		if (floroRanchBuffData.IsShowEffect)
		{
			this.EffectShowBuffList.RemoveAt(this.EffectShowBuffList.IndexOf(floroRanchBuffData));
		}
	}

	// Token: 0x0600CFAA RID: 53162 RVA: 0x00372748 File Offset: 0x00370948
	public unsafe void RefreshBuff(FloroRanchPlayBuff buff)
	{
		FloroRanchBuffData floroRanchBuffData;
		if (!this.BuffMap.TryGetValue(buff.PlayIncId, out floroRanchBuffData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "Buff is not exist!";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", this.Info());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", buff.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BuffInstanceId", buff.PlayIncId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		floroRanchBuffData.RefreshBuffData(buff);
	}

	// Token: 0x0600CFAB RID: 53163 RVA: 0x003727FC File Offset: 0x003709FC
	public void AddBuffDataToShowList(FloroRanchBuffData buffData)
	{
		if (buffData.IsShowOnTip)
		{
			this.TipShowBuffList.Add(buffData);
		}
		if (buffData.IsShowEffect)
		{
			this.EffectShowBuffList.Add(buffData);
		}
	}

	// Token: 0x0600CFAC RID: 53164 RVA: 0x00372828 File Offset: 0x00370A28
	[NullableContext(2)]
	public FloroRanchBuffData GetMinRemindDayBuff()
	{
		if (this.EffectShowBuffList.Count == 0)
		{
			return null;
		}
		FloroRanchBuffData floroRanchBuffData = this.EffectShowBuffList[0];
		foreach (FloroRanchBuffData floroRanchBuffData2 in this.EffectShowBuffList)
		{
			if (floroRanchBuffData2.RemindDay < floroRanchBuffData.RemindDay)
			{
				floroRanchBuffData = floroRanchBuffData2;
			}
		}
		return floroRanchBuffData;
	}

	// Token: 0x0600CFAD RID: 53165 RVA: 0x003728A4 File Offset: 0x00370AA4
	public override string Info()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 4);
		defaultInterpolatedStringHandler.AppendLiteral("EntityId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.EntityId);
		defaultInterpolatedStringHandler.AppendLiteral(", EntityType: ");
		defaultInterpolatedStringHandler.AppendFormatted<EFloroRanchEntityType>(this.EntityType);
		defaultInterpolatedStringHandler.AppendLiteral(", Point: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.Point);
		defaultInterpolatedStringHandler.AppendLiteral(", TagId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.TagId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600CFAE RID: 53166 RVA: 0x00372928 File Offset: 0x00370B28
	public override string DebugInfo()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("EntityId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.EntityId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600CFAF RID: 53167 RVA: 0x0037295F File Offset: 0x00370B5F
	public void Remove()
	{
		this.IsRemoveInternal = true;
	}

	// Token: 0x170010F9 RID: 4345
	// (get) Token: 0x0600CFB0 RID: 53168 RVA: 0x00372968 File Offset: 0x00370B68
	public bool IsValid
	{
		get
		{
			return !this.IsRemoveInternal;
		}
	}

	// Token: 0x040062DA RID: 25306
	public int EntityId;

	// Token: 0x040062DB RID: 25307
	public EFloroRanchEntityType EntityType = EFloroRanchEntityType.Card;

	// Token: 0x040062DC RID: 25308
	public int ConfigId;

	// Token: 0x040062DD RID: 25309
	public int Point;

	// Token: 0x040062DE RID: 25310
	public int LastPoint;

	// Token: 0x040062DF RID: 25311
	public int StartStage;

	// Token: 0x040062E0 RID: 25312
	public int StartDay;

	// Token: 0x040062E1 RID: 25313
	public int TagId;

	// Token: 0x040062E2 RID: 25314
	public int Count = 1;

	// Token: 0x040062E3 RID: 25315
	public int Income;

	// Token: 0x040062E4 RID: 25316
	public FloroRanchCurrencyData DailySaleData = new FloroRanchCurrencyData(ECurrencyType.Salary);

	// Token: 0x040062E5 RID: 25317
	public readonly List<FloroRanchBuffData> TipShowBuffList = new List<FloroRanchBuffData>();

	// Token: 0x040062E6 RID: 25318
	private readonly List<FloroRanchBuffData> EffectShowBuffList = new List<FloroRanchBuffData>();

	// Token: 0x040062E7 RID: 25319
	public readonly Dictionary<int, FloroRanchBuffData> BuffMap = new Dictionary<int, FloroRanchBuffData>();

	// Token: 0x040062E8 RID: 25320
	public readonly FloroRanchTagData TagData = new FloroRanchTagData();

	// Token: 0x040062E9 RID: 25321
	private bool IsRemoveInternal;
}
