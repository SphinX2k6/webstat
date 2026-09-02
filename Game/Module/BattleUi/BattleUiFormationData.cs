using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Fight.FollowShooter;
using AkiClient.Game.Aki.Data.Fight.UI;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F73 RID: 24435
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiFormationData
	{
		// Token: 0x0603D55E RID: 251230 RVA: 0x00F994FC File Offset: 0x00F976FC
		public void Init()
		{
			this.IsInit = true;
			string stringConfig = ConfigCommonParamById.GetStringConfig("EnvironmentPropertyInfoPath");
			Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>(stringConfig, delegate([Nullable(2)] UDataTable table, string _)
			{
				if (!this.IsInit)
				{
					return;
				}
				this.EnvironmentPropertyDataTable = table;
				if (table == null)
				{
					return;
				}
				List<string> list = new List<string>();
				DataTableUtil.GetDataTableAllRowNamesFromTable(table, list);
				foreach (string text in list)
				{
					int num;
					if (int.TryParse(text, out num) && num != 0)
					{
						SUiEnvironmentProperty dataTableRow = DataTableUtil.GetDataTableRow<SUiEnvironmentProperty>(table, text);
						this.UiEnvironmentPropertyMap[num] = dataTableRow;
						this.EnvironmentPropertyList.Add(num);
					}
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0603D55F RID: 251231 RVA: 0x00F9953A File Offset: 0x00F9773A
		public void OnLeaveLevel()
		{
		}

		// Token: 0x0603D560 RID: 251232 RVA: 0x00F9953C File Offset: 0x00F9773C
		public void Clear()
		{
			this.IsInit = false;
			this.EnvironmentPropertyDataTable = null;
			this.EnvironmentPropertyList.Clear();
			this.UiEnvironmentPropertyMap.Clear();
			this.ClearFollowerEntity();
			this.AutoMovingSettingEnable = false;
		}

		// Token: 0x0603D561 RID: 251233 RVA: 0x00F9956F File Offset: 0x00F9776F
		[NullableContext(2)]
		public SUiEnvironmentProperty GetUiEnvironmentProperty(int formationPropertyId)
		{
			if (!this.IsInit)
			{
				return null;
			}
			if (GlobalData.IsPlayInEditor)
			{
				return DataTableUtil.GetDataTableRow<SUiEnvironmentProperty>(this.EnvironmentPropertyDataTable, formationPropertyId.ToString());
			}
			return this.UiEnvironmentPropertyMap.GetValueOrDefault(formationPropertyId);
		}

		// Token: 0x0603D562 RID: 251234 RVA: 0x00F995A4 File Offset: 0x00F977A4
		public void AddFollower(EntityHandle handle)
		{
			if (handle == this.FollowerEntityHandle)
			{
				return;
			}
			this.ClearFollowerEntity();
			this.FollowerEntityHandle = handle;
			FollowShooterComponent component = handle.Entity.GetComponent<FollowShooterComponent>();
			int? num;
			if (component == null)
			{
				num = null;
			}
			else
			{
				BP_FollowShooterConfig_C followShooterConfig = component.FollowShooterConfig;
				num = ((followShooterConfig != null) ? new int?(followShooterConfig.AimType) : null);
			}
			int? num2 = num;
			EFollowType? efollowType = (num2 != null) ? new EFollowType?((EFollowType)num2.GetValueOrDefault()) : null;
			if (efollowType != null)
			{
				EFollowType? efollowType2 = efollowType;
				EFollowType efollowType3 = EFollowType.Default;
				if (!(efollowType2.GetValueOrDefault() == efollowType3 & efollowType2 != null))
				{
					goto IL_AF;
				}
			}
			efollowType = new EFollowType?(BattleUiFormationData.FollowerMap.GetValueOrDefault(handle.PbDataId, EFollowType.Default));
			IL_AF:
			this.FollowType = efollowType.Value;
			string text;
			if (component == null)
			{
				text = null;
			}
			else
			{
				BP_FollowShooterConfig_C followShooterConfig2 = component.FollowShooterConfig;
				text = ((followShooterConfig2 != null) ? followShooterConfig2.SightResId : null);
			}
			this.SightResId = (text ?? "");
			this.SetFollowerEnable(component != null && component.GetEnable());
		}

		// Token: 0x0603D563 RID: 251235 RVA: 0x00F996A6 File Offset: 0x00F978A6
		public void RefreshFollowerConfig(EntityHandle entityHandle)
		{
			this.ClearFollowerEntity();
			this.AddFollower(entityHandle);
		}

		// Token: 0x0603D564 RID: 251236 RVA: 0x00F996B5 File Offset: 0x00F978B5
		public void RemoveFollower()
		{
			this.ClearFollowerEntity();
		}

		// Token: 0x0603D565 RID: 251237 RVA: 0x00F996BD File Offset: 0x00F978BD
		public void ChangePlayerFollowerEnable(bool isEnable)
		{
			if (this.FollowerEntityHandle == null)
			{
				return;
			}
			this.SetFollowerEnable(isEnable);
		}

		// Token: 0x0603D566 RID: 251238 RVA: 0x00F996D0 File Offset: 0x00F978D0
		private void SetFollowerEnable(bool value)
		{
			if (this.FollowerEnable == value)
			{
				return;
			}
			this.FollowerEnable = value;
			Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.BattleUiFollowerAimStateChanged, value, this.FollowType == EFollowType.Default);
			FollowHudInfo followHudInfo;
			if (BattleUiFormationData.FollowTypeToHudInfo.TryGetValue(this.FollowType, out followHudInfo))
			{
				if (this.FollowerEnable)
				{
					ControllerBase<HudUnitController>.Instance.TryCreateHud(followHudInfo.HudUnitType);
				}
				Singleton<EventSystem>.Instance.Emit<bool>(followHudInfo.EventName, value);
			}
		}

		// Token: 0x0603D567 RID: 251239 RVA: 0x00F99746 File Offset: 0x00F97946
		public EFollowType GetFollowType()
		{
			return this.FollowType;
		}

		// Token: 0x0603D568 RID: 251240 RVA: 0x00F9974E File Offset: 0x00F9794E
		public string GetSightResId()
		{
			return this.SightResId;
		}

		// Token: 0x0603D569 RID: 251241 RVA: 0x00F99756 File Offset: 0x00F97956
		public bool GetFollowerAiming()
		{
			return this.FollowerEnable && this.FollowType != EFollowType.FollowNoAim;
		}

		// Token: 0x0603D56A RID: 251242 RVA: 0x00F9976E File Offset: 0x00F9796E
		public bool GetFollowerEnable()
		{
			return this.FollowerEnable;
		}

		// Token: 0x0603D56B RID: 251243 RVA: 0x00F99776 File Offset: 0x00F97976
		[NullableContext(2)]
		public EntityHandle GetFollowerEntityHandle()
		{
			return this.FollowerEntityHandle;
		}

		// Token: 0x0603D56C RID: 251244 RVA: 0x00F99780 File Offset: 0x00F97980
		private void ClearFollowerEntity()
		{
			if (this.FollowerEnable)
			{
				this.SetFollowerEnable(false);
			}
			this.FollowerEntityHandle = null;
			FollowHudInfo followHudInfo;
			if (BattleUiFormationData.FollowTypeToHudInfo.TryGetValue(this.FollowType, out followHudInfo))
			{
				ControllerBase<HudUnitController>.Instance.TryDestroyHud(followHudInfo.HudUnitType);
			}
			this.FollowType = EFollowType.Default;
		}

		// Token: 0x17009A52 RID: 39506
		// (get) Token: 0x0603D56D RID: 251245 RVA: 0x00F997CE File Offset: 0x00F979CE
		// (set) Token: 0x0603D56E RID: 251246 RVA: 0x00F997D6 File Offset: 0x00F979D6
		public bool AutoMovingSettingEnable
		{
			get
			{
				return this.AutoMovingSettingInternal;
			}
			set
			{
				if (this.AutoMovingSettingInternal == value)
				{
					return;
				}
				this.AutoMovingSettingInternal = value;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.AutoMovingSettingChanged, value);
			}
		}

		// Token: 0x17009A53 RID: 39507
		// (get) Token: 0x0603D56F RID: 251247 RVA: 0x00F997FA File Offset: 0x00F979FA
		// (set) Token: 0x0603D570 RID: 251248 RVA: 0x00F99802 File Offset: 0x00F97A02
		public bool AutoSprintSettingEnable
		{
			get
			{
				return this.AutoSprintSettingInternal;
			}
			set
			{
				if (this.AutoSprintSettingInternal == value)
				{
					return;
				}
				this.AutoSprintSettingInternal = value;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.AutoSprintSettingChanged, value);
			}
		}

		// Token: 0x0603D572 RID: 251250 RVA: 0x00F99850 File Offset: 0x00F97A50
		// Note: this type is marked as 'beforefieldinit'.
		static BattleUiFormationData()
		{
			Dictionary<int, EFollowType> dictionary = new Dictionary<int, EFollowType>();
			dictionary[658750002] = EFollowType.FollowShoot;
			dictionary[658750003] = EFollowType.FollowShoot;
			dictionary[658750000] = EFollowType.FollowNoAim;
			BattleUiFormationData.FollowerMap = dictionary;
			Dictionary<EFollowType, FollowHudInfo> dictionary2 = new Dictionary<EFollowType, FollowHudInfo>();
			dictionary2[EFollowType.FollowShoot] = new FollowHudInfo(EHudUnitType.FollowShootAim, EEventName.SetFollowShootAimVisible);
			dictionary2[EFollowType.FollowAutoAim] = new FollowHudInfo(EHudUnitType.FollowShootAutoAim, EEventName.SetFollowShootAutoAimVisible);
			dictionary2[EFollowType.FollowVisionCar] = new FollowHudInfo(EHudUnitType.FollowShootVisionCar, EEventName.SetFollowShootAutoAimVisible);
			dictionary2[EFollowType.TDFollowShootAim] = new FollowHudInfo(EHudUnitType.TDFollowShootAim, EEventName.SetTDFollowShootAimVisible);
			dictionary2[EFollowType.FollowOnlyAutoAim] = new FollowHudInfo(EHudUnitType.FollowShootOnlyAutoAim, EEventName.SetFollowShootAutoAimVisible);
			dictionary2[EFollowType.FollowAutoAimNoRing] = new FollowHudInfo(EHudUnitType.FollowShootAutoAimNoRing, EEventName.SetFollowShootAutoAimVisible);
			BattleUiFormationData.FollowTypeToHudInfo = dictionary2;
		}

		// Token: 0x04022710 RID: 141072
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, EFollowType> FollowerMap;

		// Token: 0x04022711 RID: 141073
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyDictionary<EFollowType, FollowHudInfo> FollowTypeToHudInfo;

		// Token: 0x04022712 RID: 141074
		[Nullable(2)]
		private UDataTable EnvironmentPropertyDataTable;

		// Token: 0x04022713 RID: 141075
		public List<int> EnvironmentPropertyList = new List<int>();

		// Token: 0x04022714 RID: 141076
		public Dictionary<int, SUiEnvironmentProperty> UiEnvironmentPropertyMap = new Dictionary<int, SUiEnvironmentProperty>();

		// Token: 0x04022715 RID: 141077
		private bool IsInit;

		// Token: 0x04022716 RID: 141078
		[Nullable(2)]
		private EntityHandle FollowerEntityHandle;

		// Token: 0x04022717 RID: 141079
		private EFollowType FollowType;

		// Token: 0x04022718 RID: 141080
		private string SightResId = string.Empty;

		// Token: 0x04022719 RID: 141081
		private bool FollowerEnable;

		// Token: 0x0402271A RID: 141082
		private bool AutoMovingSettingInternal;

		// Token: 0x0402271B RID: 141083
		private bool AutoSprintSettingInternal;
	}
}
