using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006002 RID: 24578
	[NullableContext(2)]
	[Nullable(0)]
	public class EntityHeadIconItem : UiPanelBase
	{
		// Token: 0x0603DE61 RID: 253537 RVA: 0x00FC9CCC File Offset: 0x00FC7ECC
		public void InitEntityId(int entityId)
		{
			this.EntityId = entityId;
			this.EntityHandle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
			EntityHandle entityHandle = this.EntityHandle;
			PawnHeadInfoComponent pawnHeadInfoComponent;
			if (entityHandle == null)
			{
				pawnHeadInfoComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				pawnHeadInfoComponent = ((entity != null) ? entity.GetComponent<PawnHeadInfoComponent>() : null);
			}
			this.PawnHeadInfoComponent = pawnHeadInfoComponent;
		}

		// Token: 0x0603DE62 RID: 253538 RVA: 0x00FC9D0A File Offset: 0x00FC7F0A
		public virtual void Update()
		{
			this.RefreshAlpha();
		}

		// Token: 0x0603DE63 RID: 253539 RVA: 0x00FC9D14 File Offset: 0x00FC7F14
		protected void RefreshAlpha()
		{
			if (this.RootItem == null)
			{
				return;
			}
			bool headDialogVisible = this.GetHeadDialogVisible();
			if (headDialogVisible == this.HeadDialogVisible)
			{
				return;
			}
			this.HeadDialogVisible = headDialogVisible;
			this.RootItem.SetAlpha(headDialogVisible ? 0.2f : 1f);
		}

		// Token: 0x0603DE64 RID: 253540 RVA: 0x00FC9D5C File Offset: 0x00FC7F5C
		protected bool GetHeadDialogVisible()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return false;
			}
			PawnHeadInfoComponent pawnHeadInfoComponent = this.PawnHeadInfoComponent;
			return pawnHeadInfoComponent != null && pawnHeadInfoComponent.IsDialogTextActive();
		}

		// Token: 0x04022B83 RID: 142211
		protected int EntityId;

		// Token: 0x04022B84 RID: 142212
		protected EntityHandle EntityHandle;

		// Token: 0x04022B85 RID: 142213
		protected PawnHeadInfoComponent PawnHeadInfoComponent;

		// Token: 0x04022B86 RID: 142214
		protected bool HeadDialogVisible;
	}
}
