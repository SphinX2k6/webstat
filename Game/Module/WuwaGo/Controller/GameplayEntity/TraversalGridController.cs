using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B16 RID: 19222
	[NullableContext(1)]
	[Nullable(0)]
	public class TraversalGridController : GameplayEntityControllerBase
	{
		// Token: 0x06032218 RID: 205336 RVA: 0x00C8B77C File Offset: 0x00C8997C
		public TraversalGridController(WuWaGoGameplayEntityBase entity, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(entity, gameData, gameMode)
		{
		}

		// Token: 0x06032219 RID: 205337 RVA: 0x00C8B788 File Offset: 0x00C89988
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			if (this.Entity.EntityType != EWuWaGoEntityType.StartGrid)
			{
				this.GridRef = this.GameData.GetGridById(this.Entity.StandGridId);
				WuWaGoGrid gridRef = this.GridRef;
				if (gridRef != null)
				{
					gridRef.AddOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnOccupiedChanged));
				}
				WuWaGoGrid gridRef2 = this.GridRef;
				int num = (gridRef2 != null) ? gridRef2.OccupiedUnitId : 0;
				if (num != 0)
				{
					this.HandleOccupiedChanged(num);
				}
			}
			return true;
		}

		// Token: 0x0603221A RID: 205338 RVA: 0x00C8B805 File Offset: 0x00C89A05
		protected override void OnDestroy()
		{
			WuWaGoGrid gridRef = this.GridRef;
			if (gridRef != null)
			{
				gridRef.RemoveOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnOccupiedChanged));
			}
			this.GridRef = null;
			base.OnDestroy();
		}

		// Token: 0x0603221B RID: 205339 RVA: 0x00C8B834 File Offset: 0x00C89A34
		private void HandleOccupiedChanged(int unitId)
		{
			WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
			int? num = (mainControlRole != null) ? new int?(mainControlRole.Id) : null;
			if (num == null || unitId != num.Value)
			{
				return;
			}
			if (this.Entity.SetState(EGameplayEntityState.Activated))
			{
				WuWaGoGrid gridRef = this.GridRef;
				if (gridRef != null)
				{
					gridRef.RemoveOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnOccupiedChanged));
				}
				this.GridRef = null;
			}
		}

		// Token: 0x0603221C RID: 205340 RVA: 0x00C8B8AC File Offset: 0x00C89AAC
		private void OnOccupiedChanged(WuWaGoGrid grid, int prevUnitId, int currentUnitId)
		{
			this.HandleOccupiedChanged(currentUnitId);
		}

		// Token: 0x0603221D RID: 205341 RVA: 0x00C8B8B8 File Offset: 0x00C89AB8
		protected override UniTask OnExecuteAction()
		{
			TraversalGridController.<OnExecuteAction>d__6 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<TraversalGridController.<OnExecuteAction>d__6>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x0401D4D1 RID: 120017
		[Nullable(2)]
		private WuWaGoGrid GridRef;
	}
}
