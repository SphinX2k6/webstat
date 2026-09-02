using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F6 RID: 24822
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarContainer : BattleVisibleChildView
	{
		// Token: 0x0603EB6C RID: 256876 RVA: 0x0100E35C File Offset: 0x0100C55C
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.Ignore);
			this.PhantomContainer = (param as UUIItem);
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			this.EntityId = ((getCurrentEntity != null) ? getCurrentEntity.Id : 0);
			this.LoadAllSpecialEnergyBar();
			this.MotorcycleSpecialEnergyBar.Init(this.RootItem, new Action(this.OnEnergyBarEnableChange));
			this.RefreshAllSpecialEnergyBarVisible();
			this.AddEvents();
		}

		// Token: 0x0603EB6D RID: 256877 RVA: 0x0100E3D0 File Offset: 0x0100C5D0
		protected override void OnBeforeDestroy()
		{
			this.CurRoleBar = null;
			foreach (RoleSpecialEnergyBar roleSpecialEnergyBar in this.RoleBarMap.Values)
			{
				roleSpecialEnergyBar.Destroy();
			}
			this.MotorcycleSpecialEnergyBar.Destroy();
		}

		// Token: 0x0603EB6E RID: 256878 RVA: 0x0100E438 File Offset: 0x0100C638
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603EB6F RID: 256879 RVA: 0x0100E448 File Offset: 0x0100C648
		public void Tick(float delta)
		{
			foreach (RoleSpecialEnergyBar roleSpecialEnergyBar in this.RoleBarMap.Values)
			{
				roleSpecialEnergyBar.Tick(delta);
			}
			this.MotorcycleSpecialEnergyBar.Tick(delta);
		}

		// Token: 0x0603EB70 RID: 256880 RVA: 0x0100E4AC File Offset: 0x0100C6AC
		public void OnChangeRole(BattleUiRoleData roleData)
		{
			int? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				num = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			}
			int? num2 = num;
			this.EntityId = num2.GetValueOrDefault();
			if (this.EntityId != 0)
			{
				RoleSpecialEnergyBar roleSpecialEnergyBar;
				if (ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.IsSpecialEnergyBarEditorModeOpen && this.RoleBarMap.TryGetValue(this.EntityId, out roleSpecialEnergyBar))
				{
					roleSpecialEnergyBar.Destroy();
					this.RoleBarMap.Remove(this.EntityId);
				}
				this.LoadSpecialEnergyBar(roleData).Forget();
			}
			this.RefreshAllSpecialEnergyBarVisible();
		}

		// Token: 0x0603EB71 RID: 256881 RVA: 0x0100E54C File Offset: 0x0100C74C
		public void OnRemoveEntity(int entityId)
		{
			RoleSpecialEnergyBar roleSpecialEnergyBar;
			if (this.RoleBarMap.Remove(entityId, out roleSpecialEnergyBar))
			{
				roleSpecialEnergyBar.Destroy();
				if (this.CurRoleBar == roleSpecialEnergyBar)
				{
					this.CurRoleBar = null;
				}
			}
		}

		// Token: 0x0603EB72 RID: 256882 RVA: 0x0100E57F File Offset: 0x0100C77F
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoaded));
			this.MotorcycleSpecialEnergyBar.AddEvents();
		}

		// Token: 0x0603EB73 RID: 256883 RVA: 0x0100E5A8 File Offset: 0x0100C7A8
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoaded));
			this.MotorcycleSpecialEnergyBar.RemoveEvents();
		}

		// Token: 0x0603EB74 RID: 256884 RVA: 0x0100E5D1 File Offset: 0x0100C7D1
		private void OnFormationLoaded()
		{
			this.LoadAllSpecialEnergyBar();
			this.RefreshAllSpecialEnergyBarVisible();
		}

		// Token: 0x0603EB75 RID: 256885 RVA: 0x0100E5E0 File Offset: 0x0100C7E0
		private void LoadAllSpecialEnergyBar()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				int? num = (entityHandle != null) ? new int?(entityHandle.Id) : null;
				if (num != null)
				{
					BattleUiRoleData roleData = ModelBase<BattleUiModel>.Instance.GetRoleData(num.Value);
					if (roleData != null)
					{
						this.LoadSpecialEnergyBar(roleData).Forget();
					}
				}
			}
		}

		// Token: 0x0603EB76 RID: 256886 RVA: 0x0100E67C File Offset: 0x0100C87C
		[NullableContext(1)]
		private UniTask LoadSpecialEnergyBar(BattleUiRoleData roleData)
		{
			SpecialEnergyBarContainer.<LoadSpecialEnergyBar>d__15 <LoadSpecialEnergyBar>d__;
			<LoadSpecialEnergyBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadSpecialEnergyBar>d__.<>4__this = this;
			<LoadSpecialEnergyBar>d__.roleData = roleData;
			<LoadSpecialEnergyBar>d__.<>1__state = -1;
			<LoadSpecialEnergyBar>d__.<>t__builder.Start<SpecialEnergyBarContainer.<LoadSpecialEnergyBar>d__15>(ref <LoadSpecialEnergyBar>d__);
			return <LoadSpecialEnergyBar>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB77 RID: 256887 RVA: 0x0100E6C8 File Offset: 0x0100C8C8
		private void RefreshAllSpecialEnergyBarVisible()
		{
			foreach (KeyValuePair<int, RoleSpecialEnergyBar> keyValuePair in this.RoleBarMap)
			{
				int num;
				RoleSpecialEnergyBar roleSpecialEnergyBar;
				keyValuePair.Deconstruct(out num, out roleSpecialEnergyBar);
				int num2 = num;
				RoleSpecialEnergyBar roleSpecialEnergyBar2 = roleSpecialEnergyBar;
				if (num2 == this.EntityId && !this.MotorcycleSpecialEnergyBar.IsEnable())
				{
					roleSpecialEnergyBar2.SetVisible(true);
					this.CurRoleBar = roleSpecialEnergyBar2;
				}
				else
				{
					roleSpecialEnergyBar2.SetVisible(false);
				}
			}
		}

		// Token: 0x0603EB78 RID: 256888 RVA: 0x0100E750 File Offset: 0x0100C950
		private void OnEnergyBarEnableChange()
		{
			this.RefreshAllSpecialEnergyBarVisible();
		}

		// Token: 0x040232BB RID: 144059
		private UUIItem PhantomContainer;

		// Token: 0x040232BC RID: 144060
		private int EntityId;

		// Token: 0x040232BD RID: 144061
		private RoleSpecialEnergyBar CurRoleBar;

		// Token: 0x040232BE RID: 144062
		[Nullable(1)]
		private readonly Dictionary<int, RoleSpecialEnergyBar> RoleBarMap = new Dictionary<int, RoleSpecialEnergyBar>();

		// Token: 0x040232BF RID: 144063
		[Nullable(1)]
		private readonly MotorcycleSpecialEnergyBar MotorcycleSpecialEnergyBar = new MotorcycleSpecialEnergyBar();
	}
}
