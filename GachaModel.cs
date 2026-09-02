using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CF8 RID: 7416
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GachaModel : ModelBase<GachaModel>
{
	// Token: 0x0600D9BA RID: 55738 RVA: 0x003A6A00 File Offset: 0x003A4C00
	public bool IsLimit(ProtoGachaInfo gachaInfo)
	{
		return gachaInfo.BeginTime != 0.0 || gachaInfo.EndTime != 0.0;
	}

	// Token: 0x0600D9BB RID: 55739 RVA: 0x003A6A2C File Offset: 0x003A4C2C
	public bool IsValid(ProtoGachaInfo gachaInfo)
	{
		if (!this.IsLimit(gachaInfo))
		{
			return true;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return serverTime >= gachaInfo.BeginTime && (serverTime < gachaInfo.EndTime || gachaInfo.EndTime == 0.0);
	}

	// Token: 0x0600D9BC RID: 55740 RVA: 0x003A6A78 File Offset: 0x003A4C78
	[NullableContext(2)]
	public ICommonShowRoleInfo GetCachedGachaInfo()
	{
		if (this.CachedGachaInfo != null && this.CachedGachaInfo.Length != 0)
		{
			ICommonShowRoleInfo result = this.CachedGachaInfo[0];
			ICommonShowRoleInfo[] array = new ICommonShowRoleInfo[this.CachedGachaInfo.Length - 1];
			for (int i = 1; i < this.CachedGachaInfo.Length; i++)
			{
				array[i - 1] = this.CachedGachaInfo[i];
			}
			this.CachedGachaInfo = array;
			return result;
		}
		return null;
	}

	// Token: 0x0600D9BD RID: 55741 RVA: 0x003A6ADC File Offset: 0x003A4CDC
	public void CacheGachaInfo(ICommonShowRoleInfo info)
	{
		if (this.CachedGachaInfo == null)
		{
			this.CachedGachaInfo = new ICommonShowRoleInfo[]
			{
				info
			};
			return;
		}
		ICommonShowRoleInfo[] array = new ICommonShowRoleInfo[this.CachedGachaInfo.Length + 1];
		for (int i = 0; i < this.CachedGachaInfo.Length; i++)
		{
			array[i] = this.CachedGachaInfo[i];
		}
		array[this.CachedGachaInfo.Length] = info;
		this.CachedGachaInfo = array;
	}

	// Token: 0x17001152 RID: 4434
	// (get) Token: 0x0600D9BE RID: 55742 RVA: 0x003A6B42 File Offset: 0x003A4D42
	// (set) Token: 0x0600D9BF RID: 55743 RVA: 0x003A6B4A File Offset: 0x003A4D4A
	public string RecordId
	{
		get
		{
			return this.RecordIdInternal;
		}
		set
		{
			this.RecordIdInternal = value;
		}
	}

	// Token: 0x17001153 RID: 4435
	// (get) Token: 0x0600D9C0 RID: 55744 RVA: 0x003A6B53 File Offset: 0x003A4D53
	// (set) Token: 0x0600D9C1 RID: 55745 RVA: 0x003A6B5B File Offset: 0x003A4D5B
	public bool CanCloseView
	{
		get
		{
			return this.CanCloseViewInternal;
		}
		set
		{
			this.CanCloseViewInternal = value;
		}
	}

	// Token: 0x17001154 RID: 4436
	// (get) Token: 0x0600D9C2 RID: 55746 RVA: 0x003A6B64 File Offset: 0x003A4D64
	// (set) Token: 0x0600D9C3 RID: 55747 RVA: 0x003A6B6C File Offset: 0x003A4D6C
	public int TodayResultCount
	{
		get
		{
			return this.TodayResultCountInternal;
		}
		set
		{
			this.TodayResultCountInternal = value;
		}
	}

	// Token: 0x17001155 RID: 4437
	// (get) Token: 0x0600D9C4 RID: 55748 RVA: 0x003A6B75 File Offset: 0x003A4D75
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ProtoGachaInfo[] GachaInfoArray
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.GachaInfoArrayInternal;
		}
	}

	// Token: 0x17001156 RID: 4438
	// (get) Token: 0x0600D9C5 RID: 55749 RVA: 0x003A6B7D File Offset: 0x003A4D7D
	// (set) Token: 0x0600D9C6 RID: 55750 RVA: 0x003A6B85 File Offset: 0x003A4D85
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public global::GachaResult[] CurGachaResult
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.CurGachaResultInternal;
		}
		[param: Nullable(new byte[]
		{
			2,
			1
		})]
		set
		{
			this.SetCurGachaResult(value);
		}
	}

	// Token: 0x0600D9C7 RID: 55751 RVA: 0x003A6B90 File Offset: 0x003A4D90
	public void SetCurGachaResult([Nullable(new byte[]
	{
		2,
		1
	})] global::GachaResult[] result)
	{
		this.CurGachaResultInternal = result;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (this.CurGachaResultInternal != null)
		{
			foreach (global::GachaResult gachaResult in this.CurGachaResultInternal)
			{
				int? num;
				if (gachaResult == null)
				{
					num = null;
				}
				else
				{
					GachaReward proto_GachaReward = gachaResult.Proto_GachaReward;
					num = ((proto_GachaReward != null) ? new int?(proto_GachaReward.ItemId) : null);
				}
				int? num2 = num;
				int? num3;
				if (gachaResult == null)
				{
					num3 = null;
				}
				else
				{
					GachaReward proto_GachaReward2 = gachaResult.Proto_GachaReward;
					num3 = ((proto_GachaReward2 != null) ? new int?(proto_GachaReward2.ItemCount) : null);
				}
				int? num4 = num3;
				if (num2 != null && num4 != null)
				{
					dictionary[num2.Value] = (dictionary.ContainsKey(num2.Value) ? dictionary[num2.Value] : 0) + num4.Value;
				}
			}
			foreach (global::GachaResult gachaResult2 in this.CurGachaResultInternal)
			{
				int? num5;
				if (gachaResult2 == null)
				{
					num5 = null;
				}
				else
				{
					GachaReward proto_GachaReward3 = gachaResult2.Proto_GachaReward;
					num5 = ((proto_GachaReward3 != null) ? new int?(proto_GachaReward3.ItemId) : null);
				}
				int? num6 = num5;
				if (num6 != null)
				{
					RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(num6.Value);
					if (roleInfoById != null)
					{
						gachaResult2.IsNew = ControllerBase<GachaController>.Instance.IsNewRole(roleInfoById.Value.Id);
					}
					else
					{
						int[] array = LocalStorage.GetPlayer<int[]>(ELocalStoragePlayerKey.GachaWeaponRecord, null) ?? new int[0];
						bool flag = false;
						int[] array2 = array;
						for (int j = 0; j < array2.Length; j++)
						{
							if (array2[j] == num6.Value)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							gachaResult2.IsNew = true;
							int[] array3 = new int[array.Length + 1];
							for (int k = 0; k < array.Length; k++)
							{
								array3[k] = array[k];
							}
							array3[array.Length] = num6.Value;
							LocalStorage.SetPlayer<int[]>(ELocalStoragePlayerKey.GachaWeaponRecord, array3);
						}
						else
						{
							gachaResult2.IsNew = false;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600D9C8 RID: 55752 RVA: 0x003A6DB8 File Offset: 0x003A4FB8
	[return: Nullable(2)]
	public ProtoGachaInfo GetGachaInfoByResourceId(string resourceId)
	{
		if (this.GachaInfoArrayInternal != null)
		{
			foreach (ProtoGachaInfo protoGachaInfo in this.GachaInfoArrayInternal)
			{
				if (protoGachaInfo.ResourcesId == resourceId)
				{
					return protoGachaInfo;
				}
			}
		}
		return null;
	}

	// Token: 0x0600D9C9 RID: 55753 RVA: 0x003A6DF8 File Offset: 0x003A4FF8
	public bool IsAllDiscountUsedUp(ProtoGachaInfo info)
	{
		if (info.GachaDiscountInfos.Length == 0)
		{
			return true;
		}
		foreach (GachaDiscountInfo gachaDiscountInfo in info.GachaDiscountInfos)
		{
			if (gachaDiscountInfo.UsedTimes < gachaDiscountInfo.LimitTimes)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600D9CA RID: 55754 RVA: 0x003A6E3C File Offset: 0x003A503C
	public EffectiveGachaButtonInfo[] GetEffectiveGachaButtons(ProtoGachaInfo info)
	{
		List<EffectiveGachaButtonInfo> list = new List<EffectiveGachaButtonInfo>();
		bool flag = this.IsAllDiscountUsedUp(info);
		if (info.GachaConsumes == null)
		{
			return list.ToArray();
		}
		foreach (GachaConsume gachaConsume in info.GachaConsumes)
		{
			int times = gachaConsume.Times;
			int consume = gachaConsume.Consume;
			GachaDiscountInfo gachaDiscountInfo = null;
			foreach (GachaDiscountInfo gachaDiscountInfo2 in info.GachaDiscountInfos)
			{
				if (gachaDiscountInfo2.Times == times)
				{
					gachaDiscountInfo = gachaDiscountInfo2;
					break;
				}
			}
			bool flag2 = gachaDiscountInfo != null && gachaDiscountInfo.UsedTimes < gachaDiscountInfo.LimitTimes;
			string tagCustomText;
			info.DiscountTagDetails.TryGetValue(times, out tagCustomText);
			if (flag2)
			{
				list.Add(EffectiveGachaButtonInfo.MakeDiscount(times, gachaDiscountInfo.DiscountConsume, consume, tagCustomText));
			}
			else if (!info.OnlyViewDiscount || flag)
			{
				list.Add(EffectiveGachaButtonInfo.MakePlain(times, consume, null));
			}
		}
		list.Any((EffectiveGachaButtonInfo button) => button.IsDiscount);
		return list.ToArray();
	}

	// Token: 0x0600D9CB RID: 55755 RVA: 0x003A6F54 File Offset: 0x003A5154
	[return: Nullable(2)]
	public GachaTagInfo GetSelectPoolButtonTag(ProtoGachaInfo info)
	{
		EffectiveGachaButtonInfo[] effectiveGachaButtons = this.GetEffectiveGachaButtons(info);
		EffectiveGachaButtonInfo effectiveGachaButtonInfo = null;
		EffectiveGachaButtonInfo effectiveGachaButtonInfo2 = null;
		foreach (EffectiveGachaButtonInfo effectiveGachaButtonInfo3 in effectiveGachaButtons)
		{
			if (effectiveGachaButtonInfo3.Times == 10)
			{
				effectiveGachaButtonInfo = effectiveGachaButtonInfo3;
			}
			else if (effectiveGachaButtonInfo3.Times == 1)
			{
				effectiveGachaButtonInfo2 = effectiveGachaButtonInfo3;
			}
		}
		GachaTagInfo result;
		if ((result = ((effectiveGachaButtonInfo != null) ? effectiveGachaButtonInfo.GetCustomTag() : null)) == null && (result = ((effectiveGachaButtonInfo2 != null) ? effectiveGachaButtonInfo2.GetCustomTag() : null)) == null && (result = ((effectiveGachaButtonInfo != null) ? effectiveGachaButtonInfo.GetDiscountTag() : null)) == null)
		{
			if (effectiveGachaButtonInfo2 == null)
			{
				return null;
			}
			result = effectiveGachaButtonInfo2.GetDiscountTag();
		}
		return result;
	}

	// Token: 0x0600D9CC RID: 55756 RVA: 0x003A6FD8 File Offset: 0x003A51D8
	protected override bool OnInit()
	{
		this.CachedGachaInfo = new ICommonShowRoleInfo[0];
		return true;
	}

	// Token: 0x0600D9CD RID: 55757 RVA: 0x003A6FE8 File Offset: 0x003A51E8
	protected override bool OnClear()
	{
		this.CanCloseView = true;
		this.GachaInfoArrayInternal = null;
		this.CurGachaResultInternal = null;
		this.GachaPoolOpenRecord = null;
		this.GachaPoolSet = null;
		if (this.CachedGachaInfo != null)
		{
			this.CachedGachaInfo = new ICommonShowRoleInfo[0];
		}
		this.CachedGachaInfo = null;
		return true;
	}

	// Token: 0x0600D9CE RID: 55758 RVA: 0x003A7034 File Offset: 0x003A5234
	public void InitGachaInfoMap(GachaInfo[] gachaInfoArray)
	{
		this.GachaInfoArrayInternal = new ProtoGachaInfo[gachaInfoArray.Length];
		for (int i = 0; i < gachaInfoArray.Length; i++)
		{
			this.GachaInfoArrayInternal[i] = new ProtoGachaInfo(gachaInfoArray[i]);
		}
		for (int j = 0; j < this.GachaInfoArrayInternal.Length - 1; j++)
		{
			for (int k = 0; k < this.GachaInfoArrayInternal.Length - 1 - j; k++)
			{
				if (this.GachaInfoArrayInternal[k].Sort > this.GachaInfoArrayInternal[k + 1].Sort)
				{
					ProtoGachaInfo protoGachaInfo = this.GachaInfoArrayInternal[k];
					this.GachaInfoArrayInternal[k] = this.GachaInfoArrayInternal[k + 1];
					this.GachaInfoArrayInternal[k + 1] = protoGachaInfo;
				}
			}
		}
	}

	// Token: 0x0600D9CF RID: 55759 RVA: 0x003A70DD File Offset: 0x003A52DD
	public bool CheckGachaValid(ProtoGachaInfo gachaInfo)
	{
		return this.IsValid(gachaInfo);
	}

	// Token: 0x0600D9D0 RID: 55760 RVA: 0x003A70E8 File Offset: 0x003A52E8
	public bool CheckGachaValidByGachaId(int gachaId)
	{
		ProtoGachaInfo gachaInfo = this.GetGachaInfo(gachaId);
		return gachaInfo != null && this.CheckGachaValid(gachaInfo);
	}

	// Token: 0x0600D9D1 RID: 55761 RVA: 0x003A710C File Offset: 0x003A530C
	public GachaPoolData[] GetValidGachaList()
	{
		List<GachaPoolData> list = new List<GachaPoolData>();
		if (ModelBase<GachaModel>.Instance.GachaInfoArray != null)
		{
			foreach (ProtoGachaInfo protoGachaInfo in ModelBase<GachaModel>.Instance.GachaInfoArray)
			{
				if (ModelBase<GachaModel>.Instance.CheckGachaValid(protoGachaInfo))
				{
					int usePoolId = protoGachaInfo.UsePoolId;
					ProtoGachaPoolInfo protoGachaPoolInfo = (usePoolId > 0) ? protoGachaInfo.GetPoolInfo(usePoolId) : protoGachaInfo.GetFirstValidPool();
					if (protoGachaPoolInfo != null)
					{
						list.Add(new GachaPoolData(protoGachaInfo, protoGachaPoolInfo));
					}
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600D9D2 RID: 55762 RVA: 0x003A718C File Offset: 0x003A538C
	[NullableContext(0)]
	public ValueTuple<bool, EConfirmBoxConfigId?> CheckCountIsEnough([Nullable(1)] ProtoGachaInfo gachaInfo, int count)
	{
		if (gachaInfo.DailyLimitTimes > 0 && gachaInfo.TodayTimes + count > gachaInfo.DailyLimitTimes)
		{
			return new ValueTuple<bool, EConfirmBoxConfigId?>(false, new EConfirmBoxConfigId?(EConfirmBoxConfigId.GachaTimeIsMax));
		}
		if (gachaInfo.TotalLimitTimes > 0 && gachaInfo.TotalTimes + count > gachaInfo.TotalLimitTimes)
		{
			return new ValueTuple<bool, EConfirmBoxConfigId?>(false, new EConfirmBoxConfigId?(EConfirmBoxConfigId.TotalLimitTimes));
		}
		if (this.TodayResultCountInternal >= 0 && count > this.TodayResultCountInternal)
		{
			return new ValueTuple<bool, EConfirmBoxConfigId?>(false, new EConfirmBoxConfigId?(EConfirmBoxConfigId.TodayResult));
		}
		return new ValueTuple<bool, EConfirmBoxConfigId?>(true, null);
	}

	// Token: 0x0600D9D3 RID: 55763 RVA: 0x003A721C File Offset: 0x003A541C
	public bool IsTotalTimesZero(ProtoGachaInfo gachaInfo)
	{
		return gachaInfo.TotalLimitTimes > 0 && gachaInfo.TotalTimes >= gachaInfo.TotalLimitTimes;
	}

	// Token: 0x0600D9D4 RID: 55764 RVA: 0x003A723C File Offset: 0x003A543C
	[NullableContext(2)]
	public ProtoGachaInfo GetGachaInfo(int gachaId)
	{
		if (this.GachaInfoArray != null)
		{
			foreach (ProtoGachaInfo protoGachaInfo in this.GachaInfoArray)
			{
				if (protoGachaInfo.Id == gachaId)
				{
					return protoGachaInfo;
				}
			}
		}
		return null;
	}

	// Token: 0x0600D9D5 RID: 55765 RVA: 0x003A7278 File Offset: 0x003A5478
	public bool RecordGachaInfo(ProtoGachaInfo gachaInfo)
	{
		if (this.GachaPoolSet != null && !this.GachaPoolSet.Contains(gachaInfo.Id))
		{
			this.GachaPoolSet.Add(gachaInfo.Id);
			if (this.GachaPoolOpenRecord != null)
			{
				int[] array = new int[this.GachaPoolOpenRecord.Length + 1];
				for (int i = 0; i < this.GachaPoolOpenRecord.Length; i++)
				{
					array[i] = this.GachaPoolOpenRecord[i];
				}
				array[this.GachaPoolOpenRecord.Length] = gachaInfo.Id;
				this.GachaPoolOpenRecord = array;
			}
			LocalStorage.SetPlayer<int[]>(ELocalStoragePlayerKey.GachaPoolOpenRecord, this.GachaPoolOpenRecord);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnOpenGachaChanged);
			return true;
		}
		return false;
	}

	// Token: 0x0600D9D6 RID: 55766 RVA: 0x003A7324 File Offset: 0x003A5524
	public void InitGachaPoolOpenRecord()
	{
		this.GachaPoolOpenRecord = (LocalStorage.GetPlayer<int[]>(ELocalStoragePlayerKey.GachaPoolOpenRecord, null) ?? Array.Empty<int>());
		this.GachaPoolSet = new HashSet<int>();
		foreach (int item in this.GachaPoolOpenRecord)
		{
			this.GachaPoolSet.Add(item);
		}
	}

	// Token: 0x0600D9D7 RID: 55767 RVA: 0x003A7378 File Offset: 0x003A5578
	public void UpdateCount(int gachaId, int count, int poolId)
	{
		this.CurGachaPoolId = poolId;
		this.TodayResultCountInternal -= count;
		if (this.GachaInfoArray != null)
		{
			foreach (ProtoGachaInfo protoGachaInfo in this.GachaInfoArray)
			{
				if (protoGachaInfo.Id == gachaId)
				{
					protoGachaInfo.TodayTimes += count;
					protoGachaInfo.TotalTimes += count;
					return;
				}
			}
		}
	}

	// Token: 0x0600D9D8 RID: 55768 RVA: 0x003A73E4 File Offset: 0x003A55E4
	public bool CheckNewGachaPool()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Gacha;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "当前打开过的卡池";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GachaPoolOpenRecord", this.GachaPoolOpenRecord);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.GachaInfoArray == null)
		{
			return false;
		}
		foreach (ProtoGachaInfo protoGachaInfo in this.GachaInfoArray)
		{
			if (this.GachaPoolSet != null && !this.GachaPoolSet.Contains(protoGachaInfo.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600D9D9 RID: 55769 RVA: 0x003A7460 File Offset: 0x003A5660
	public bool CheckNewGachaPoolById(int id)
	{
		return this.GachaPoolSet != null && !this.GachaPoolSet.Contains(id);
	}

	// Token: 0x0600D9DA RID: 55770 RVA: 0x003A747C File Offset: 0x003A567C
	public UniTask PreloadGachaSequence(int[] itemIds)
	{
		GachaModel.<PreloadGachaSequence>d__51 <PreloadGachaSequence>d__;
		<PreloadGachaSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadGachaSequence>d__.<>4__this = this;
		<PreloadGachaSequence>d__.itemIds = itemIds;
		<PreloadGachaSequence>d__.<>1__state = -1;
		<PreloadGachaSequence>d__.<>t__builder.Start<GachaModel.<PreloadGachaSequence>d__51>(ref <PreloadGachaSequence>d__);
		return <PreloadGachaSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600D9DB RID: 55771 RVA: 0x003A74C7 File Offset: 0x003A56C7
	[return: Nullable(2)]
	public ULevelSequence GetLoadedSequence(string path)
	{
		if (!this.SequenceCache.ContainsKey(path))
		{
			return null;
		}
		return this.SequenceCache[path];
	}

	// Token: 0x0600D9DC RID: 55772 RVA: 0x003A74E8 File Offset: 0x003A56E8
	public UniTask PreloadGachaSequenceOne(int itemId)
	{
		GachaModel.<PreloadGachaSequenceOne>d__53 <PreloadGachaSequenceOne>d__;
		<PreloadGachaSequenceOne>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadGachaSequenceOne>d__.<>4__this = this;
		<PreloadGachaSequenceOne>d__.itemId = itemId;
		<PreloadGachaSequenceOne>d__.<>1__state = -1;
		<PreloadGachaSequenceOne>d__.<>t__builder.Start<GachaModel.<PreloadGachaSequenceOne>d__53>(ref <PreloadGachaSequenceOne>d__);
		return <PreloadGachaSequenceOne>d__.<>t__builder.Task;
	}

	// Token: 0x0600D9DD RID: 55773 RVA: 0x003A7534 File Offset: 0x003A5734
	public string GetGachaSequencePath(int itemId)
	{
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId);
		if (ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId) == InventoryDefine.EItemDataType.WeaponItem)
		{
			GachaDefine.EGachaViewType? gachaViewType = ConfigBase<GachaConfig>.Instance.GetGachaViewType(this.CurGachaPoolId);
			GachaViewTypeInfo? gachaViewTypeInfo = (gachaViewType != null) ? ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig((int)gachaViewType.Value) : null;
			int id = (gachaViewTypeInfo == null || gachaViewTypeInfo.Value.WeaponUseGachaAnim) ? gachaTextureInfo.Value.ShowSequence : 3;
			GachaWeaponSeqConfig? gachaWeaponSeqConfigById = ConfigBase<GachaConfig>.Instance.GetGachaWeaponSeqConfigById(id);
			if (gachaWeaponSeqConfigById != null)
			{
				return gachaWeaponSeqConfigById.Value.SequencePath;
			}
		}
		return ConfigBase<GachaConfig>.Instance.GetGachaSequenceConfigById(gachaTextureInfo.Value.ShowSequence).Value.SequencePath;
	}

	// Token: 0x0600D9DE RID: 55774 RVA: 0x003A761C File Offset: 0x003A581C
	public int GetGachaSequenceEndFrame(int itemId)
	{
		if (ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId) != InventoryDefine.EItemDataType.WeaponItem)
		{
			return 190;
		}
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId);
		GachaDefine.EGachaViewType? gachaViewType = ConfigBase<GachaConfig>.Instance.GetGachaViewType(this.CurGachaPoolId);
		GachaViewTypeInfo? gachaViewTypeInfo = (gachaViewType != null) ? ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig((int)gachaViewType.Value) : null;
		int id = (gachaViewTypeInfo == null || gachaViewTypeInfo.Value.WeaponUseGachaAnim) ? gachaTextureInfo.Value.ShowSequence : 3;
		return ConfigBase<GachaConfig>.Instance.GetGachaWeaponSeqConfigById(id).Value.BeforeEndFrame;
	}

	// Token: 0x0600D9DF RID: 55775 RVA: 0x003A76D0 File Offset: 0x003A58D0
	public void ReleaseLoadGachaSequence()
	{
		foreach (int id in this.LoadHandlers)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(id);
		}
		foreach (int handleId in this.UiModelLoadHandlers)
		{
			Singleton<UiModelResourcesManager>.Instance.CancelUiModelResourceLoad(handleId);
		}
		foreach (ULevelSequence levelSequences in this.SequenceCache.Values)
		{
			UKuroSequenceRuntimeFunctionLibrary.HandleSeqTexStreaming(levelSequences, false, true);
		}
		this.SequenceCache.Clear();
	}

	// Token: 0x0600D9E0 RID: 55776 RVA: 0x003A77C0 File Offset: 0x003A59C0
	public bool IsRolePool(GachaDefine.EGachaViewType type)
	{
		return type == GachaDefine.EGachaViewType.NewPlayer || type == GachaDefine.EGachaViewType.RoleCommon || type == GachaDefine.EGachaViewType.RoleUp || type == GachaDefine.EGachaViewType.AnniversaryRole || type == GachaDefine.EGachaViewType.NewPlayerCustom || type == GachaDefine.EGachaViewType.CarnivalRole || type == GachaDefine.EGachaViewType.CyberRole || type == GachaDefine.EGachaViewType.OldCarnivalRole;
	}

	// Token: 0x0600D9E1 RID: 55777 RVA: 0x003A77E8 File Offset: 0x003A59E8
	public GachaDefine.EItemQuality GetGachaQuality(int itemId)
	{
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
		int result = 0;
		if (itemIdType != InventoryDefine.EItemDataType.RoleItem)
		{
			if (itemIdType != InventoryDefine.EItemDataType.WeaponItem)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Gacha;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "抽卡获得物品的类型错误，必须是角色或武器";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				result = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId).Value.QualityId;
			}
		}
		else
		{
			RoleInfo? roleInfo;
			result = ((ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId) != null) ? roleInfo.GetValueOrDefault().QualityId : 0);
		}
		return (GachaDefine.EItemQuality)result;
	}

	// Token: 0x0600D9E2 RID: 55778 RVA: 0x003A7888 File Offset: 0x003A5A88
	public string GetGachaRecordUrlPrefix()
	{
		return Singleton<BaseConfigController>.Instance.GetGachaUrl().GachaRecord;
	}

	// Token: 0x0600D9E3 RID: 55779 RVA: 0x003A7899 File Offset: 0x003A5A99
	public string GetServerArea()
	{
		if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			return "cn";
		}
		return "global";
	}

	// Token: 0x040067E5 RID: 26597
	public bool IsCacheShowNewNotify;

	// Token: 0x040067E6 RID: 26598
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ProtoGachaInfo[] GachaInfoArrayInternal;

	// Token: 0x040067E7 RID: 26599
	private int TodayResultCountInternal;

	// Token: 0x040067E8 RID: 26600
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private global::GachaResult[] CurGachaResultInternal;

	// Token: 0x040067E9 RID: 26601
	[Nullable(2)]
	private int[] GachaPoolOpenRecord;

	// Token: 0x040067EA RID: 26602
	[Nullable(2)]
	private HashSet<int> GachaPoolSet;

	// Token: 0x040067EB RID: 26603
	private bool CanCloseViewInternal = true;

	// Token: 0x040067EC RID: 26604
	private string RecordIdInternal = "";

	// Token: 0x040067ED RID: 26605
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ICommonShowRoleInfo[] CachedGachaInfo;

	// Token: 0x040067EE RID: 26606
	private readonly List<int> LoadHandlers = new List<int>();

	// Token: 0x040067EF RID: 26607
	private readonly Dictionary<string, ULevelSequence> SequenceCache = new Dictionary<string, ULevelSequence>();

	// Token: 0x040067F0 RID: 26608
	private readonly List<int> UiModelLoadHandlers = new List<int>();

	// Token: 0x040067F1 RID: 26609
	private const int WEAPON_DEFAULT_SEQID = 3;

	// Token: 0x040067F2 RID: 26610
	private int CurGachaPoolId;
}
