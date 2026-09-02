using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B1 RID: 20657
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopHotRoleGridItem : LoopScrollMediumItemGrid<RoleDevelopData>
	{
		// Token: 0x0603539E RID: 218014 RVA: 0x00D57B28 File Offset: 0x00D55D28
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
		}

		// Token: 0x0603539F RID: 218015 RVA: 0x00D57B32 File Offset: 0x00D55D32
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x060353A0 RID: 218016 RVA: 0x00D57B3C File Offset: 0x00D55D3C
		protected override void OnRefresh(RoleDevelopData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RoleDevelopRoleBaseData developRoleData = data.GetDevelopRoleData();
			ForecastCharacterMediumItemGrid parameters = new ForecastCharacterMediumItemGrid
			{
				Data = data,
				IconPath = developRoleData.GetRoleIconPath(),
				BottomText = developRoleData.GetName(),
				RoleDevTag = new ERoleDevelopHotRoleTag?(data.GetHotRoleTag())
			};
			base.Apply<ForecastCharacterMediumItemGrid>(parameters);
		}

		// Token: 0x060353A1 RID: 218017 RVA: 0x00D57B94 File Offset: 0x00D55D94
		public override object GetKey(RoleDevelopData data, int gridIndex)
		{
			return data.GetId();
		}
	}
}
