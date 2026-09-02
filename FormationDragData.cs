using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B48 RID: 6984
[NullableContext(1)]
[Nullable(0)]
public class FormationDragData
{
	// Token: 0x0600C9F6 RID: 51702 RVA: 0x0035B368 File Offset: 0x00359568
	public void ClearData()
	{
		this.DragRoleItem = null;
		foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
		{
			formationRoleSlot.Reset();
		}
		this.FormationRoleViewList.Clear();
		this.CustomShieldHotKeyComponentSet.Clear();
	}

	// Token: 0x040060A6 RID: 24742
	public List<FormationRoleSlot> FormationRoleViewList = new List<FormationRoleSlot>();

	// Token: 0x040060A7 RID: 24743
	[Nullable(2)]
	public FormationRoleDragItem DragRoleItem;

	// Token: 0x040060A8 RID: 24744
	public HashSet<int> CustomShieldHotKeyComponentSet = new HashSet<int>();

	// Token: 0x040060A9 RID: 24745
	[Nullable(2)]
	public Action<int, int, int, int> ExchangeRoleCallBack;

	// Token: 0x040060AA RID: 24746
	public int DragItemPosition;

	// Token: 0x040060AB RID: 24747
	public Vector2D CurDragPos = Vector2D.Create();

	// Token: 0x040060AC RID: 24748
	public Vector2D LastDragPos = Vector2D.Create();

	// Token: 0x040060AD RID: 24749
	public Vector2D TempAnchorOffset = Vector2D.Create();

	// Token: 0x040060AE RID: 24750
	public Vector TempPointerPosition = Vector.Create();
}
