using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.MailBind;

// Token: 0x02001CB0 RID: 7344
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FunctionModel : ModelBase<FunctionModel>
{
	// Token: 0x0600D787 RID: 55175 RVA: 0x0039A220 File Offset: 0x00398420
	protected override bool OnInit()
	{
		this.ExCheckConditionMap[EFunctionType.Activity] = new Func<bool>(this.CheckActivityOpen);
		this.ExCheckConditionMap[EFunctionType.UserFeedback] = new Func<bool>(this.CheckCustomerServiceOpen);
		this.ExCheckConditionMap[EFunctionType.KuroStreet] = new Func<bool>(this.CheckKuroStreetOpen);
		this.ExCheckConditionMap[EFunctionType.MailBind] = new Func<bool>(this.CheckMailBindOpen);
		this.ExCheckConditionMap[EFunctionType.DirectTrainPro] = new Func<bool>(this.CheckDirectTrainProOpen);
		this.ExCheckConditionMap[EFunctionType.GameIntroduction] = new Func<bool>(this.CheckPioneerClientLimit);
		return true;
	}

	// Token: 0x0600D788 RID: 55176 RVA: 0x0039A2D6 File Offset: 0x003984D6
	private bool CheckActivityOpen()
	{
		return ModelBase<ActivityModel>.Instance.GetIfShowActivity();
	}

	// Token: 0x0600D789 RID: 55177 RVA: 0x0039A2E2 File Offset: 0x003984E2
	private bool CheckCustomerServiceOpen()
	{
		return ControllerBase<KuroSdkController>.Instance.NeedShowCustomerService();
	}

	// Token: 0x0600D78A RID: 55178 RVA: 0x0039A2EE File Offset: 0x003984EE
	private bool CheckKuroStreetOpen()
	{
		return ControllerBase<ChannelController>.Instance.CheckKuroStreetOpen();
	}

	// Token: 0x0600D78B RID: 55179 RVA: 0x0039A2FA File Offset: 0x003984FA
	private bool CheckMailBindOpen()
	{
		return ModelBase<MailBindModel>.Instance.CheckGlobalMailBindOpen();
	}

	// Token: 0x0600D78C RID: 55180 RVA: 0x0039A306 File Offset: 0x00398506
	private bool CheckDirectTrainProOpen()
	{
		return ActivityDirectTrainHelper.IsProOpen;
	}

	// Token: 0x0600D78D RID: 55181 RVA: 0x0039A30D File Offset: 0x0039850D
	private bool CheckPioneerClientLimit()
	{
		return !FeatureRestrictionTemplate.TemplateForPioneerClient.Check();
	}

	// Token: 0x0600D78E RID: 55182 RVA: 0x0039A31C File Offset: 0x0039851C
	[NullableContext(2)]
	public void SetFunctionOpenInfo(FuncOpenNotify funcOpenNotify)
	{
		if (funcOpenNotify == null)
		{
			return;
		}
		foreach (Function function in funcOpenNotify.Func)
		{
			FunctionInstance functionInstance = new FunctionInstance(function.Flag, (EFunctionType)function.Id);
			this.FunctionMap[function.Id] = new FunctionInstance(function.Flag, (EFunctionType)function.Id);
			bool isOpen = functionInstance.GetIsOpen();
			Singleton<EventSystem>.Instance.Emit<EFunctionType, bool>(EEventName.OnFunctionOpenSet, (EFunctionType)function.Id, isOpen);
		}
	}

	// Token: 0x0600D78F RID: 55183 RVA: 0x0039A3B8 File Offset: 0x003985B8
	[NullableContext(2)]
	public void UpdateFunctionOpenInfo(FuncOpenUpdateNotify functionOpenUpdateNotify)
	{
		if (functionOpenUpdateNotify == null)
		{
			return;
		}
		foreach (Function function in functionOpenUpdateNotify.Func)
		{
			FunctionInstance functionInstance;
			if (!this.FunctionMap.TryGetValue(function.Id, out functionInstance))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Functional;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "当前刷新的功能id不在功能列表中";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("功能Id", function.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				functionInstance.SetFlag(function.Flag);
				bool isOpen = functionInstance.GetIsOpen();
				if (isOpen)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Functional;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "功能数据更新";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", function.Id);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				Singleton<EventSystem>.Instance.Emit<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, (EFunctionType)function.Id, isOpen);
				FunctionCondition? config = ConfigFunctionConditionByFunctionId.GetConfig(function.Id, true);
				if (isOpen && (config != null && config.GetValueOrDefault().ShowUIType == 1) && !ModelBase<SundryModel>.Instance.IsBlockTips && !functionOpenUpdateNotify.Silent)
				{
					this.NewOpenFunctionList.Add(config.Value);
				}
				if (ModelBase<SundryModel>.Instance.IsBlockTips)
				{
					Singleton<Log>.Instance.Info(ELogModule.Functional, ELogAuthor.XXJ, "[UpdateFunctionOpenInfo]用了GM屏蔽功能开启界面显示", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFunctionOpenUpdateNotify);
	}

	// Token: 0x0600D790 RID: 55184 RVA: 0x0039A554 File Offset: 0x00398754
	public unsafe void UpdateFunctionOpenLockByBehaviorTree(int functionId, bool isLockByBehaviorTree)
	{
		FunctionInstance functionInstance;
		if (!this.FunctionMap.TryGetValue(functionId, out functionInstance))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[BehaviorTree]当前的功能id不在功能列表中";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("功能Id", functionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		functionInstance.SetIsLockByBehaviorTree(isLockByBehaviorTree);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Functional;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "[UpdateFunctionOpenLockByBehaviorTree]行为树执行了系统功能的启用/禁用";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("功能ID", functionId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否禁用", isLockByBehaviorTree);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600D791 RID: 55185 RVA: 0x0039A604 File Offset: 0x00398804
	public void RefreshInfoManualState(int[] functionIdList)
	{
		foreach (int num in functionIdList)
		{
			FunctionInstance functionInstance;
			if (!this.FunctionMap.TryGetValue(num, out functionInstance))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Functional;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "当前刷新的功能id不在功能列表中";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("功能Id", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				FunctionCondition? config = ConfigFunctionConditionByFunctionId.GetConfig(num, true);
				if (functionInstance.GetIsOpen() && !ModelBase<SundryModel>.Instance.IsBlockTips && config != null)
				{
					this.NewOpenFunctionList.Add(config.Value);
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Functional;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "手动开启功能开启界面成功";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("FunctionId", num);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				if (ModelBase<SundryModel>.Instance.IsBlockTips)
				{
					Singleton<Log>.Instance.Info(ELogModule.Functional, ELogAuthor.XXJ, "[RefreshInfoManualState]用了GM屏蔽功能开启界面显示", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}
	}

	// Token: 0x0600D792 RID: 55186 RVA: 0x0039A700 File Offset: 0x00398900
	public FunctionCondition? PopNewOpenFunctionList()
	{
		if (this.IsExistNewOpenFunction())
		{
			FunctionCondition value = this.NewOpenFunctionList[0];
			this.NewOpenFunctionList.RemoveAt(0);
			return new FunctionCondition?(value);
		}
		return null;
	}

	// Token: 0x0600D793 RID: 55187 RVA: 0x0039A73C File Offset: 0x0039893C
	public bool IsExistNewOpenFunction()
	{
		return this.NewOpenFunctionList.Count > 0;
	}

	// Token: 0x0600D794 RID: 55188 RVA: 0x0039A74C File Offset: 0x0039894C
	public void ClearNewOpenFunctionList()
	{
		this.NewOpenFunctionList = new List<FunctionCondition>();
	}

	// Token: 0x0600D795 RID: 55189 RVA: 0x0039A75C File Offset: 0x0039895C
	public List<int> GetNewOpenFunctionIdList()
	{
		List<int> list = new List<int>();
		foreach (FunctionCondition functionCondition in this.NewOpenFunctionList)
		{
			list.Add(functionCondition.FunctionId);
		}
		return list;
	}

	// Token: 0x17001143 RID: 4419
	// (get) Token: 0x0600D796 RID: 55190 RVA: 0x0039A7BC File Offset: 0x003989BC
	public int PlayerId
	{
		get
		{
			return ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		}
	}

	// Token: 0x0600D797 RID: 55191 RVA: 0x0039A7DC File Offset: 0x003989DC
	[NullableContext(2)]
	public string GetPlayerName()
	{
		if (GlobalData.IsPlayInEditor)
		{
			string text = UiBlueprintFunctionLibrary.TestSceneLoadPlayer();
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		return ModelBase<PlayerInfoModel>.Instance.GetStringPropById(EPlayerInfoNumber.Name);
	}

	// Token: 0x0600D798 RID: 55192 RVA: 0x0039A80B File Offset: 0x00398A0B
	public int? GetPlayerLevel()
	{
		return ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.Level);
	}

	// Token: 0x0600D799 RID: 55193 RVA: 0x0039A818 File Offset: 0x00398A18
	public int? GetPlayerExp()
	{
		return ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.Experience);
	}

	// Token: 0x0600D79A RID: 55194 RVA: 0x0039A828 File Offset: 0x00398A28
	public string GetPlayerCashCoin()
	{
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.CashCoin);
		if (numberPropById == null)
		{
			return "0";
		}
		return numberPropById.Value.ToString();
	}

	// Token: 0x0600D79B RID: 55195 RVA: 0x0039A860 File Offset: 0x00398A60
	public int? GetWorldPermission()
	{
		return ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.WorldPermission);
	}

	// Token: 0x0600D79C RID: 55196 RVA: 0x0039A870 File Offset: 0x00398A70
	[NullableContext(2)]
	public string GetFunctionHitTextId(int functionId)
	{
		FunctionCondition? config = ConfigFunctionConditionByFunctionId.GetConfig(functionId, true);
		if (config != null)
		{
			int openConditionId = config.Value.OpenConditionId;
			if (openConditionId != 0)
			{
				return LevelGeneralCommons.GetConditionGroupHintText(openConditionId);
			}
		}
		return null;
	}

	// Token: 0x0600D79D RID: 55197 RVA: 0x0039A8A9 File Offset: 0x00398AA9
	public bool IsOpen(EFunctionType functionId)
	{
		return this.IsOpen((int)functionId);
	}

	// Token: 0x0600D79E RID: 55198 RVA: 0x0039A8B4 File Offset: 0x00398AB4
	public bool IsOpen(int functionId)
	{
		FunctionInstance functionInstance;
		return functionId == 0 || (this.FunctionMap.TryGetValue(functionId, out functionInstance) && functionInstance.GetIsOpen());
	}

	// Token: 0x0600D79F RID: 55199 RVA: 0x0039A8E0 File Offset: 0x00398AE0
	public bool IsLimit(int functionId)
	{
		FunctionInstance valueOrDefault = this.FunctionMap.GetValueOrDefault(functionId);
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId != 0 && valueOrDefault != null)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				int[] array = config.GetValueOrDefault().FuncLimit();
				flag = ((array != null) ? new bool?(array.Contains(functionId)) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600D7A0 RID: 55200 RVA: 0x0039A95C File Offset: 0x00398B5C
	public bool IsShow(int functionId)
	{
		FunctionInstance functionInstance;
		return this.FunctionMap.TryGetValue(functionId, out functionInstance) && functionInstance.GetIsShow();
	}

	// Token: 0x0600D7A1 RID: 55201 RVA: 0x0039A984 File Offset: 0x00398B84
	public bool IsLockByBehaviorTree(int functionId)
	{
		FunctionInstance functionInstance;
		return functionId != 0 && this.FunctionMap.TryGetValue(functionId, out functionInstance) && functionInstance.GetIsLockByBehaviorTree();
	}

	// Token: 0x0600D7A2 RID: 55202 RVA: 0x0039A9B0 File Offset: 0x00398BB0
	[NullableContext(2)]
	public FunctionInstance GetFunctionInstance(int functionId)
	{
		FunctionInstance result;
		this.FunctionMap.TryGetValue(functionId, out result);
		return result;
	}

	// Token: 0x0600D7A3 RID: 55203 RVA: 0x0039A9D0 File Offset: 0x00398BD0
	public int[] GetShowFunctionIdList()
	{
		List<int> list = new List<int>();
		List<FunctionMenu> list2 = ConfigCommon.ToList<FunctionMenu>(ConfigBase<FunctionConfig>.Instance.GetAllFunctionList());
		if (list2 != null)
		{
			list2.Sort(delegate(FunctionMenu aConfig, FunctionMenu bConfig)
			{
				int num = aConfig.SortIndex - bConfig.SortIndex;
				if (num == 0)
				{
					return aConfig.FunctionId - bConfig.FunctionId;
				}
				return num;
			});
			foreach (FunctionMenu functionMenu in list2)
			{
				FunctionInstance functionInstance;
				if (this.FunctionMap.TryGetValue(functionMenu.FunctionId, out functionInstance))
				{
					Func<bool> func;
					this.ExCheckConditionMap.TryGetValue((EFunctionType)functionMenu.FunctionId, out func);
					bool flag = func == null || func();
					if (functionInstance.GetIsOpen() && flag)
					{
						list.Add(functionMenu.FunctionId);
					}
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600D7A4 RID: 55204 RVA: 0x0039AAB4 File Offset: 0x00398CB4
	public ERedDotName? GetFunctionItemRedDotName(int functionId)
	{
		if (functionId <= 10072)
		{
			if (functionId <= 10040)
			{
				switch (functionId)
				{
				case 10001:
					return new ERedDotName?(ERedDotName.FunctionRole);
				case 10002:
					return new ERedDotName?(ERedDotName.FunctionInventory);
				case 10003:
					return new ERedDotName?(ERedDotName.FunctionCalabash);
				case 10004:
					return new ERedDotName?(ERedDotName.FunctionViewQuestBtn);
				case 10005:
				case 10006:
				case 10007:
				case 10008:
				case 10012:
				case 10014:
					break;
				case 10009:
					return new ERedDotName?(ERedDotName.FunctionGacha);
				case 10010:
					return new ERedDotName?(ERedDotName.FunctionPayShop);
				case 10011:
					return new ERedDotName?(ERedDotName.FunctionFriend);
				case 10013:
					return new ERedDotName?(ERedDotName.Achievement);
				case 10015:
					return new ERedDotName?(ERedDotName.FunctionMap);
				default:
					switch (functionId)
					{
					case 10022:
						return new ERedDotName?(ERedDotName.FunctionTutorial);
					case 10023:
						return new ERedDotName?(ERedDotName.FunctionAdventure);
					case 10024:
					case 10025:
					case 10027:
						break;
					case 10026:
						return new ERedDotName?(ERedDotName.FunctionPhantomExploreSet);
					case 10028:
						return new ERedDotName?(ERedDotName.CustomerService);
					case 10029:
						return new ERedDotName?(ERedDotName.InfluenceReputation);
					default:
						if (functionId == 10040)
						{
							return new ERedDotName?(ERedDotName.BattlePass);
						}
						break;
					}
					break;
				}
			}
			else if (functionId <= 10053)
			{
				if (functionId == 10041)
				{
					return new ERedDotName?(ERedDotName.RoleHandBook);
				}
				if (functionId == 10053)
				{
					return new ERedDotName?(ERedDotName.ActivityEntrance);
				}
			}
			else
			{
				if (functionId == 10058)
				{
					return new ERedDotName?(ERedDotName.FunctionKuroStreet);
				}
				if (functionId == 10072)
				{
					return new ERedDotName?(ERedDotName.FunctionMailBind);
				}
			}
		}
		else if (functionId <= 10098)
		{
			if (functionId == 10086)
			{
				return new ERedDotName?(ERedDotName.Introduction);
			}
			if (functionId == 10095)
			{
				return new ERedDotName?(ERedDotName.ActivityDirectTrainProEntry);
			}
			if (functionId == 10098)
			{
				return new ERedDotName?(ERedDotName.FunctionMotorDevelop);
			}
		}
		else if (functionId <= 10140)
		{
			switch (functionId)
			{
			case 10130:
				return new ERedDotName?(ERedDotName.FunctionPhoneMsg);
			case 10131:
				return new ERedDotName?(ERedDotName.Infrastructure);
			case 10132:
				break;
			case 10133:
				return new ERedDotName?(ERedDotName.FunctionWeatherCentral);
			default:
				if (functionId == 10140)
				{
					return new ERedDotName?(ERedDotName.FeedbackReward);
				}
				break;
			}
		}
		else
		{
			if (functionId == 10150)
			{
				return new ERedDotName?(ERedDotName.VillageInfr);
			}
			if (functionId == 10156)
			{
				return new ERedDotName?(ERedDotName.SheriffMap);
			}
		}
		return null;
	}

	// Token: 0x0600D7A5 RID: 55205 RVA: 0x0039AD0E File Offset: 0x00398F0E
	public bool RedDotFunctionPhantomCondition()
	{
		return false;
	}

	// Token: 0x040066AB RID: 26283
	private readonly Dictionary<int, FunctionInstance> FunctionMap = new Dictionary<int, FunctionInstance>();

	// Token: 0x040066AC RID: 26284
	private List<FunctionCondition> NewOpenFunctionList = new List<FunctionCondition>();

	// Token: 0x040066AD RID: 26285
	private readonly Dictionary<EFunctionType, Func<bool>> ExCheckConditionMap = new Dictionary<EFunctionType, Func<bool>>();
}
