using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D95 RID: 7573
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseMarkView : UiPanelBase
{
	// Token: 0x0600DF2A RID: 57130 RVA: 0x003C0C9E File Offset: 0x003BEE9E
	[NullableContext(2)]
	public TrapDefenseMarkItem GetMarkData()
	{
		return ModelBase<TrapDefenseModel>.Instance.MapData.GetDynamicMarkInfoByMarkId(this.MarkId);
	}

	// Token: 0x0600DF2B RID: 57131 RVA: 0x003C0CB5 File Offset: 0x003BEEB5
	public TrapDefenseMarkView(int markId)
	{
		this.MarkId = markId;
	}

	// Token: 0x1700117D RID: 4477
	// (get) Token: 0x0600DF2C RID: 57132 RVA: 0x003C0CE1 File Offset: 0x003BEEE1
	public bool NeedUpdatePosition
	{
		get
		{
			return this.NeedUpdatePositionInner;
		}
	}

	// Token: 0x0600DF2D RID: 57133 RVA: 0x003C0CE9 File Offset: 0x003BEEE9
	public virtual void OnTowerDefenseStepUpdate(ETowerDefenseEventProcessStatus status)
	{
	}

	// Token: 0x0600DF2E RID: 57134 RVA: 0x003C0CEC File Offset: 0x003BEEEC
	public virtual void UpdatePosition(float scale, Vector2D centerOffset)
	{
		TrapDefenseMarkItem markData = this.GetMarkData();
		if (markData == null)
		{
			return;
		}
		Vector uiPosition = markData.UiPosition;
		if (uiPosition.IsZero())
		{
			return;
		}
		Vector2D vector2D = Vector2D.Create(uiPosition.X, uiPosition.Y);
		Vector2D vector2D2 = Vector2D.Create();
		vector2D.Multiply((double)scale, vector2D2).Subtraction(centerOffset, vector2D2);
		this.SetAnchorOffset(vector2D2, null);
		if (base.IsShow)
		{
			base.GetRootItem().SetAlpha(1f);
		}
	}

	// Token: 0x0600DF2F RID: 57135 RVA: 0x003C0D5C File Offset: 0x003BEF5C
	public void SetAnchorOffset(Vector2D value, [Nullable(new byte[]
	{
		2,
		1
	})] UUIItem[] relativeItems = null)
	{
		if (!value.Equals(this.CurrentAnchorOffset, 9.999999747378752E-05))
		{
			UUIItem rootItem = base.GetRootItem();
			if (rootItem != null)
			{
				rootItem.SetAnchorOffset(value.ToUeVector2D(false));
			}
			if (relativeItems != null)
			{
				for (int i = 0; i < relativeItems.Length; i++)
				{
					relativeItems[i].SetAnchorOffset(value.ToUeVector2D(false));
				}
			}
			this.CurrentAnchorOffset.Set(value.X, value.Y);
		}
	}

	// Token: 0x04006B53 RID: 27475
	public int MarkId;

	// Token: 0x04006B54 RID: 27476
	private readonly Vector2D CurrentAnchorOffset = Vector2D.Create(0.0, 0.0);

	// Token: 0x04006B55 RID: 27477
	protected bool NeedUpdatePositionInner;
}
