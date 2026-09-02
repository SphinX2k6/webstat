using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x0200495C RID: 18780
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleHookDetectRestriction : IStaticVariableResetter
	{
		// Token: 0x060311A6 RID: 201126 RVA: 0x00C3771F File Offset: 0x00C3591F
		static MotorcycleHookDetectRestriction()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleHookDetectRestriction.CreateStaticDefaultValue), new Action(MotorcycleHookDetectRestriction.ResetStaticDefaultValue));
		}

		// Token: 0x060311A7 RID: 201127 RVA: 0x00C37740 File Offset: 0x00C35940
		public static void CreateStaticDefaultValue()
		{
			MotorcycleHookDetectRestriction.MotorcycleHookSkillIds = new HashSet<int>
			{
				10001027,
				10001028,
				10001029,
				10001006,
				10002001,
				10001035
			};
			Dictionary<int, EHookInteractType> dictionary = new Dictionary<int, EHookInteractType>();
			dictionary[10001027] = EHookInteractType.FixedPointHook;
			dictionary[10001028] = EHookInteractType.CableWay;
			dictionary[10001029] = EHookInteractType.PilotThrow;
			dictionary[10001006] = EHookInteractType.MotorPullInteract;
			dictionary[10002001] = EHookInteractType.MotorEject;
			dictionary[10001035] = EHookInteractType.KiteHook;
			MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType = dictionary;
		}

		// Token: 0x060311A8 RID: 201128 RVA: 0x00C377F5 File Offset: 0x00C359F5
		public static void ResetStaticDefaultValue()
		{
			MotorcycleHookDetectRestriction.MotorcycleHookSkillIds = null;
			MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType = null;
		}

		// Token: 0x060311A9 RID: 201129 RVA: 0x00C37804 File Offset: 0x00C35A04
		public MotorcycleHookDetectRestriction([Nullable(new byte[]
		{
			1,
			2
		})] Func<MotorcycleExploreComponent> getExploreComponent)
		{
			HashSet<EHookInteractType> hashSet = new HashSet<EHookInteractType>();
			foreach (EHookInteractType item in MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType.Values)
			{
				hashSet.Add(item);
			}
			this.EnabledTypes = hashSet;
			base..ctor();
			this.GetExploreComponent = getExploreComponent;
		}

		// Token: 0x060311AA RID: 201130 RVA: 0x00C37884 File Offset: 0x00C35A84
		public unsafe bool SetDisabled(bool disabled, string reason)
		{
			if (this.Disabled == disabled)
			{
				return false;
			}
			this.Disabled = disabled;
			if (disabled)
			{
				this.ClearActiveTarget(reason);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[MotorcycleHookDetectRestriction] 设置钩锁探测禁用状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Disabled", disabled);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return true;
		}

		// Token: 0x060311AB RID: 201131 RVA: 0x00C37906 File Offset: 0x00C35B06
		public bool IsDisabled()
		{
			return this.Disabled || this.AreAllSkillIdsDisabled();
		}

		// Token: 0x060311AC RID: 201132 RVA: 0x00C37918 File Offset: 0x00C35B18
		public bool CanHandleSkillId(int skillId)
		{
			return MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType.ContainsKey(skillId);
		}

		// Token: 0x060311AD RID: 201133 RVA: 0x00C37928 File Offset: 0x00C35B28
		public unsafe bool SetDisabledBySkillId(int skillId, bool disabled, string reason)
		{
			EHookInteractType ehookInteractType;
			if (!MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType.TryGetValue(skillId, out ehookInteractType))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[MotorcycleHookDetectRestriction] 设置技能钩锁探测禁用状态失败, 技能Id未映射钩锁类型";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Disabled", disabled);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			if (this.DisabledSkillIds.Contains(skillId) == disabled)
			{
				return false;
			}
			if (disabled)
			{
				this.DisabledSkillIds.Add(skillId);
				this.EnabledTypes.Remove(ehookInteractType);
				if (this.IsDisabled())
				{
					this.ClearActiveTarget(reason);
				}
				else
				{
					this.ClearTargetByType(ehookInteractType, reason);
				}
			}
			else
			{
				this.DisabledSkillIds.Remove(skillId);
				this.EnabledTypes.Add(ehookInteractType);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "[MotorcycleHookDetectRestriction] 设置技能钩锁探测禁用状态";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("SkillId", skillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("HookType", ehookInteractType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Disabled", disabled);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("AllDisabled", this.AreAllSkillIdsDisabled());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
			return true;
		}

		// Token: 0x060311AE RID: 201134 RVA: 0x00C37AD4 File Offset: 0x00C35CD4
		public bool ClearSkillIdRestrictions(string reason)
		{
			if (this.DisabledSkillIds.Count == 0)
			{
				return false;
			}
			this.DisabledSkillIds.Clear();
			foreach (EHookInteractType item in MotorcycleHookDetectRestriction.MotorcycleHookSkillIdToType.Values)
			{
				this.EnabledTypes.Add(item);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[MotorcycleHookDetectRestriction] 清空局部钩锁探测屏蔽";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x060311AF RID: 201135 RVA: 0x00C37B74 File Offset: 0x00C35D74
		public HashSet<EHookInteractType> GetEnabledTypes()
		{
			return this.EnabledTypes;
		}

		// Token: 0x060311B0 RID: 201136 RVA: 0x00C37B7C File Offset: 0x00C35D7C
		public bool IsTypeDisabled(EHookInteractType hookType)
		{
			return !this.EnabledTypes.Contains(hookType);
		}

		// Token: 0x060311B1 RID: 201137 RVA: 0x00C37B90 File Offset: 0x00C35D90
		private bool AreAllSkillIdsDisabled()
		{
			foreach (int item in MotorcycleHookDetectRestriction.MotorcycleHookSkillIds)
			{
				if (!this.DisabledSkillIds.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060311B2 RID: 201138 RVA: 0x00C37BF0 File Offset: 0x00C35DF0
		private void ClearActiveTarget(string reason)
		{
			MotorcycleExploreComponent motorcycleExploreComponent = this.GetExploreComponent();
			if (motorcycleExploreComponent == null)
			{
				return;
			}
			motorcycleExploreComponent.ClearDetectedTarget(reason);
		}

		// Token: 0x060311B3 RID: 201139 RVA: 0x00C37C08 File Offset: 0x00C35E08
		private void ClearTargetByType(EHookInteractType hookType, string reason)
		{
			MotorcycleExploreComponent motorcycleExploreComponent = this.GetExploreComponent();
			GrapplingHookPointComponent grapplingHookPointComponent = (motorcycleExploreComponent != null) ? motorcycleExploreComponent.FocusTarget : null;
			bool flag;
			if (grapplingHookPointComponent == null)
			{
				flag = true;
			}
			else
			{
				EHookInteractType? hookInteractType = grapplingHookPointComponent.GetHookInteractType();
				flag = !(hookInteractType.GetValueOrDefault() == hookType & hookInteractType != null);
			}
			if (flag)
			{
				return;
			}
			if (motorcycleExploreComponent != null)
			{
				motorcycleExploreComponent.ClearDetectedTarget(reason);
			}
		}

		// Token: 0x0401C453 RID: 115795
		[Nullable(2)]
		public static HashSet<int> MotorcycleHookSkillIds;

		// Token: 0x0401C454 RID: 115796
		[Nullable(2)]
		private static Dictionary<int, EHookInteractType> MotorcycleHookSkillIdToType;

		// Token: 0x0401C455 RID: 115797
		private bool Disabled;

		// Token: 0x0401C456 RID: 115798
		private readonly HashSet<int> DisabledSkillIds = new HashSet<int>();

		// Token: 0x0401C457 RID: 115799
		private readonly HashSet<EHookInteractType> EnabledTypes;

		// Token: 0x0401C458 RID: 115800
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly Func<MotorcycleExploreComponent> GetExploreComponent;
	}
}
