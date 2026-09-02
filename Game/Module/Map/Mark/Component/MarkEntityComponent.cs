using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x0200582A RID: 22570
	public class MarkEntityComponent : MapComponent
	{
		// Token: 0x060395EE RID: 234990 RVA: 0x00E909A7 File Offset: 0x00E8EBA7
		public MarkEntityComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x1700923F RID: 37439
		// (get) Token: 0x060395EF RID: 234991 RVA: 0x00E909B0 File Offset: 0x00E8EBB0
		// (set) Token: 0x060395F0 RID: 234992 RVA: 0x00E909B8 File Offset: 0x00E8EBB8
		public int? EntityId { get; set; }

		// Token: 0x17009240 RID: 37440
		// (get) Token: 0x060395F1 RID: 234993 RVA: 0x00E909C1 File Offset: 0x00E8EBC1
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkEntity;
			}
		}

		// Token: 0x060395F2 RID: 234994 RVA: 0x00E909C8 File Offset: 0x00E8EBC8
		protected override void OnInit()
		{
			MapEntity parentEntity = base.ParentEntity;
			MarkGamePlayComponent markGamePlayComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay) : null;
			if (markGamePlayComponent != null)
			{
				int markId = markGamePlayComponent.MarkId;
				this.UpdateHideState(markId);
			}
		}

		// Token: 0x060395F3 RID: 234995 RVA: 0x00E909FB File Offset: 0x00E8EBFB
		protected override void OnAdd()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MarkHideState, new Action<int>(this.UpdateHideState));
		}

		// Token: 0x060395F4 RID: 234996 RVA: 0x00E90A19 File Offset: 0x00E8EC19
		protected override void OnRemove()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MarkHideState, new Action<int>(this.UpdateHideState));
		}

		// Token: 0x060395F5 RID: 234997 RVA: 0x00E90A38 File Offset: 0x00E8EC38
		private void UpdateHideState(int markId)
		{
			MapEntity parentEntity = base.ParentEntity;
			MarkGamePlayComponent markGamePlayComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay) : null;
			if (markGamePlayComponent != null && markGamePlayComponent.MarkId == markId && this.EntityId != null && ModelBase<MapModel>.Instance.IsMarkHideByServer(markGamePlayComponent.MapId, this.EntityId.Value))
			{
				markGamePlayComponent.GamePlayState = EMarkGamePlayState.Hide;
			}
		}
	}
}
