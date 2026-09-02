using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A6 RID: 24742
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleSpecialEnergyBar
	{
		// Token: 0x0603E76D RID: 255853 RVA: 0x00FF6F58 File Offset: 0x00FF5158
		[NullableContext(1)]
		public void Init(UUIItem parentItem, Action enableChange)
		{
			this.ParentItem = parentItem;
			this.EnableChangeCallback = enableChange;
			this.RefreshSpecialEnergyBar();
		}

		// Token: 0x0603E76E RID: 255854 RVA: 0x00FF6F6E File Offset: 0x00FF516E
		public bool IsEnable()
		{
			return this.EnergyBar != null;
		}

		// Token: 0x0603E76F RID: 255855 RVA: 0x00FF6F79 File Offset: 0x00FF5179
		public void Destroy()
		{
			this.RemoveMotorcycleTagTask();
			this.DestroyEnergyBar();
			this.MotorcycleEntityHandle = null;
		}

		// Token: 0x0603E770 RID: 255856 RVA: 0x00FF6F8E File Offset: 0x00FF518E
		public void Tick(float delta)
		{
			SpecialEnergyBarMotorcycle energyBar = this.EnergyBar;
			if (energyBar == null)
			{
				return;
			}
			energyBar.Tick(delta);
		}

		// Token: 0x0603E771 RID: 255857 RVA: 0x00FF6FA1 File Offset: 0x00FF51A1
		public void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.BattleUiMotorcycleStateChanged));
		}

		// Token: 0x0603E772 RID: 255858 RVA: 0x00FF6FBF File Offset: 0x00FF51BF
		public void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.BattleUiMotorcycleStateChanged));
		}

		// Token: 0x0603E773 RID: 255859 RVA: 0x00FF6FDD File Offset: 0x00FF51DD
		private void BattleUiMotorcycleStateChanged(bool b)
		{
			this.RefreshSpecialEnergyBar();
		}

		// Token: 0x0603E774 RID: 255860 RVA: 0x00FF6FE8 File Offset: 0x00FF51E8
		private void RefreshSpecialEnergyBar()
		{
			bool flag = this.IsEnable();
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				this.MotorcycleEntityHandle = ModelBase<BattleUiModel>.Instance.MotorcycleData.MotorcycleEntityHandle;
				this.RemoveMotorcycleTagTask();
				this.AddMotorcycleTagTask(this.MotorcycleEntityHandle.Entity);
			}
			else
			{
				this.RemoveMotorcycleTagTask();
				this.DestroyEnergyBar();
				this.MotorcycleEntityHandle = null;
			}
			if (flag != this.IsEnable())
			{
				Action enableChangeCallback = this.EnableChangeCallback;
				if (enableChangeCallback == null)
				{
					return;
				}
				enableChangeCallback();
			}
		}

		// Token: 0x0603E775 RID: 255861 RVA: 0x00FF7068 File Offset: 0x00FF5268
		[NullableContext(1)]
		private void AddMotorcycleTagTask(Entity entity)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			this.MotorcycleTagTask = component.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["关卡.沙虫BOSS战.开启脉冲炮弹能量槽"]), new BaseTagComponent.TTagSwitchedCallback(this.OnMotorcycleTagChange), null);
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["关卡.沙虫BOSS战.开启脉冲炮弹能量槽"]))
			{
				this.CreateEnergyBar();
			}
		}

		// Token: 0x0603E776 RID: 255862 RVA: 0x00FF70C6 File Offset: 0x00FF52C6
		private void RemoveMotorcycleTagTask()
		{
			ITagTask motorcycleTagTask = this.MotorcycleTagTask;
			if (motorcycleTagTask != null)
			{
				motorcycleTagTask.EndTask();
			}
			this.MotorcycleTagTask = null;
		}

		// Token: 0x0603E777 RID: 255863 RVA: 0x00FF70E0 File Offset: 0x00FF52E0
		private void CreateEnergyBar()
		{
			if (this.EnergyBar != null)
			{
				this.DestroyEnergyBar();
			}
			this.InitAsync(this.MotorcycleEntityHandle).Forget();
		}

		// Token: 0x0603E778 RID: 255864 RVA: 0x00FF7104 File Offset: 0x00FF5304
		[NullableContext(1)]
		private UniTask InitAsync(EntityHandle entityHandle)
		{
			MotorcycleSpecialEnergyBar.<InitAsync>d__17 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.entityHandle = entityHandle;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<MotorcycleSpecialEnergyBar.<InitAsync>d__17>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E779 RID: 255865 RVA: 0x00FF714F File Offset: 0x00FF534F
		private void DestroyEnergyBar()
		{
			if (this.EnergyBar != null)
			{
				this.EnergyBar.Destroy(null);
				this.EnergyBar = null;
			}
		}

		// Token: 0x0603E77A RID: 255866 RVA: 0x00FF716C File Offset: 0x00FF536C
		private void OnMotorcycleTagChange(int tagId, bool tagExist)
		{
			bool flag = this.IsEnable();
			if (tagExist)
			{
				this.CreateEnergyBar();
			}
			else
			{
				this.DestroyEnergyBar();
			}
			if (flag != this.IsEnable())
			{
				Action enableChangeCallback = this.EnableChangeCallback;
				if (enableChangeCallback == null)
				{
					return;
				}
				enableChangeCallback();
			}
		}

		// Token: 0x0402303C RID: 143420
		private UUIItem ParentItem;

		// Token: 0x0402303D RID: 143421
		public int EntityId;

		// Token: 0x0402303E RID: 143422
		private SpecialEnergyBarMotorcycle EnergyBar;

		// Token: 0x0402303F RID: 143423
		private EntityHandle MotorcycleEntityHandle;

		// Token: 0x04023040 RID: 143424
		private ITagTask MotorcycleTagTask;

		// Token: 0x04023041 RID: 143425
		private Action EnableChangeCallback;
	}
}
