using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603C RID: 24636
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleHonamiStoryRoleItem : UiPanelBase
	{
		// Token: 0x0603E24A RID: 254538 RVA: 0x00FDCC44 File Offset: 0x00FDAE44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E24B RID: 254539 RVA: 0x00FDCD74 File Offset: 0x00FDAF74
		protected override UniTask OnBeforeStartAsync()
		{
			BattleHonamiStoryRoleItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleHonamiStoryRoleItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E24C RID: 254540 RVA: 0x00FDCDB8 File Offset: 0x00FDAFB8
		private UniTask CreateSuitItem(BattleHonamiStoryRoleItem.EComponentType suitType)
		{
			BattleHonamiStoryRoleItem.<CreateSuitItem>d__8 <CreateSuitItem>d__;
			<CreateSuitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSuitItem>d__.<>4__this = this;
			<CreateSuitItem>d__.suitType = suitType;
			<CreateSuitItem>d__.<>1__state = -1;
			<CreateSuitItem>d__.<>t__builder.Start<BattleHonamiStoryRoleItem.<CreateSuitItem>d__8>(ref <CreateSuitItem>d__);
			return <CreateSuitItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E24D RID: 254541 RVA: 0x00FDCE03 File Offset: 0x00FDB003
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			base.GetUiNiagara(7).SetUIActive(false);
		}

		// Token: 0x0603E24E RID: 254542 RVA: 0x00FDCE23 File Offset: 0x00FDB023
		protected override void OnBeforeShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequencePurely("Start", false, false);
		}

		// Token: 0x0603E24F RID: 254543 RVA: 0x00FDCE3C File Offset: 0x00FDB03C
		protected override UniTask OnHideAsyncImplementImplement()
		{
			BattleHonamiStoryRoleItem.<OnHideAsyncImplementImplement>d__11 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<BattleHonamiStoryRoleItem.<OnHideAsyncImplementImplement>d__11>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603E250 RID: 254544 RVA: 0x00FDCE7F File Offset: 0x00FDB07F
		protected override void OnAfterHide()
		{
			Action onAfterHideCallback = this.OnAfterHideCallback;
			if (onAfterHideCallback == null)
			{
				return;
			}
			onAfterHideCallback();
		}

		// Token: 0x0603E251 RID: 254545 RVA: 0x00FDCE91 File Offset: 0x00FDB091
		protected override void OnBeforeDestroy()
		{
			this.OnAfterHideCallback = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			TimerHandle hideTimerHandle = this.HideTimerHandle;
			if (hideTimerHandle != null)
			{
				hideTimerHandle.Remove();
			}
			this.HideTimerHandle = null;
		}

		// Token: 0x0603E252 RID: 254546 RVA: 0x00FDCECB File Offset: 0x00FDB0CB
		[NullableContext(1)]
		public void RegisterOnAfterHide(Action onAfterHide)
		{
			this.OnAfterHideCallback = onAfterHide;
		}

		// Token: 0x0603E253 RID: 254547 RVA: 0x00FDCED4 File Offset: 0x00FDB0D4
		[NullableContext(1)]
		public void ShowRoleItem(HonamiStoryRoleItemData data, int duration)
		{
			int roleId = data.RoleId;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HonamiStory;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "拾取提示角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", roleId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action onAfterHideCallback = this.OnAfterHideCallback;
				if (onAfterHideCallback == null)
				{
					return;
				}
				onAfterHideCallback();
				return;
			}
			else
			{
				RoleInfo value = roleConfig.Value;
				this.SetActive(true);
				UUITexture texture = base.GetTexture(0);
				texture.SetUIActive(false);
				RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(roleId);
				string path = (roleSkinDataByRoleId != null) ? roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIconLarge : value.RoleHeadIconLarge;
				base.SetRoleIconByRoleIdOrSkinId(path, texture, roleId, new int?(value.SkinId), delegate(bool _)
				{
					UUITexture texture2 = base.GetTexture(0);
					if (texture2 == null)
					{
						return;
					}
					texture2.SetUIActive(true);
				}, null);
				if (data.BuffActive)
				{
					base.GetUiNiagara(7).SetUIActive(true);
					this.BuffEffectTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
					{
						this.BuffEffectTimerHandle = null;
						base.GetUiNiagara(7).SetUIActive(false);
					}, 1000f, null, null, true, 1f);
				}
				List<int> suitIdList = data.SuitIdList;
				List<HonamiStoryWeaponSuitActiveData> suitDataList = data.SuitDataList;
				bool flag = suitIdList == null || suitDataList == null;
				base.GetSprite(4).SetUIActive(flag);
				base.GetItem(5).SetUIActive(!flag);
				if (flag)
				{
					this.StartAutoHide(duration);
					return;
				}
				int itemSubType = data.ItemSubType;
				int count = this.SuitItems.Count;
				int num = Math.Min(suitIdList.Count, count);
				BattleHonamiStoryRoleSuitItem battleHonamiStoryRoleSuitItem = null;
				for (int i = 0; i < num; i++)
				{
					int suitId = suitIdList[i];
					HonamiStoryWeaponSuitActiveData honamiStoryWeaponSuitActiveData = suitDataList[i];
					int weaponPluginType = ModelBase<HonamiStoryModel>.Instance.GetWeaponSuitData(suitId).WeaponPluginType;
					BattleHonamiStoryRoleSuitItem battleHonamiStoryRoleSuitItem2 = this.SuitItems[i];
					battleHonamiStoryRoleSuitItem2.Refresh(honamiStoryWeaponSuitActiveData, weaponPluginType);
					battleHonamiStoryRoleSuitItem2.SetUiActive(true);
					if (honamiStoryWeaponSuitActiveData.IsActive && itemSubType == weaponPluginType)
					{
						battleHonamiStoryRoleSuitItem = battleHonamiStoryRoleSuitItem2;
					}
				}
				if (battleHonamiStoryRoleSuitItem != null)
				{
					battleHonamiStoryRoleSuitItem.PlayBurst();
				}
				for (int j = num; j < count; j++)
				{
					this.SuitItems[j].SetUiActive(false);
				}
				this.StartAutoHide(duration);
				return;
			}
		}

		// Token: 0x0603E254 RID: 254548 RVA: 0x00FDD108 File Offset: 0x00FDB308
		private void StartAutoHide(int duration)
		{
			this.HideTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.HideTimerHandle = null;
				if (!base.IsHideOrHiding)
				{
					this.SetActive(false);
				}
			}, (float)duration, null, null, true, 1f);
		}

		// Token: 0x0603E255 RID: 254549 RVA: 0x00FDD130 File Offset: 0x00FDB330
		public void HideRoleItem()
		{
			TimerHandle hideTimerHandle = this.HideTimerHandle;
			if (hideTimerHandle != null)
			{
				hideTimerHandle.Remove();
			}
			this.HideTimerHandle = null;
			if (!base.IsHideOrHiding)
			{
				this.SetActive(false);
			}
		}

		// Token: 0x04022D66 RID: 142694
		[Nullable(1)]
		private readonly List<BattleHonamiStoryRoleSuitItem> SuitItems = new List<BattleHonamiStoryRoleSuitItem>();

		// Token: 0x04022D67 RID: 142695
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04022D68 RID: 142696
		private TimerHandle HideTimerHandle;

		// Token: 0x04022D69 RID: 142697
		private TimerHandle BuffEffectTimerHandle;

		// Token: 0x04022D6A RID: 142698
		private Action OnAfterHideCallback;

		// Token: 0x0200C0FB RID: 49403
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403B6D1 RID: 243409
			RoleTexture,
			// Token: 0x0403B6D2 RID: 243410
			SuitItemA,
			// Token: 0x0403B6D3 RID: 243411
			SuitItemB,
			// Token: 0x0403B6D4 RID: 243412
			SuitItemC,
			// Token: 0x0403B6D5 RID: 243413
			EmptySprite,
			// Token: 0x0403B6D6 RID: 243414
			SuitPanel,
			// Token: 0x0403B6D7 RID: 243415
			LevelUpSprite,
			// Token: 0x0403B6D8 RID: 243416
			BuffEffect
		}
	}
}
