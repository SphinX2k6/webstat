using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DA RID: 26074
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballRoleSelectGridItem : PinballItemGridView<IPinballRoleSelectGridItemData>
	{
		// Token: 0x06041236 RID: 266806 RVA: 0x010B5AD4 File Offset: 0x010B3CD4
		public override UniTask RefreshAsync(IPinballRoleSelectGridItemData data, bool isSelected, int gridIndex)
		{
			PinballRoleSelectGridItem.<RefreshAsync>d__1 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<PinballRoleSelectGridItem.<RefreshAsync>d__1>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041237 RID: 266807 RVA: 0x010B5B20 File Offset: 0x010B3D20
		public override void Refresh(IPinballRoleSelectGridItemData data, bool isSelected, int gridIndex)
		{
			PinballRoleSelectGridItem.<>c__DisplayClass2_0 CS$<>8__locals1 = new PinballRoleSelectGridItem.<>c__DisplayClass2_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.isSelected = isSelected;
			CS$<>8__locals1.gridIndex = gridIndex;
			UiAsyncTask task = new UiAsyncTask("PinballRoleSelectGridItem.Refresh", delegate()
			{
				PinballRoleSelectGridItem.<>c__DisplayClass2_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<PinballRoleSelectGridItem.<>c__DisplayClass2_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06041238 RID: 266808 RVA: 0x010B5B74 File Offset: 0x010B3D74
		public void RefreshSelectedState(bool bJumpToLastFrame)
		{
			EToggleState state = this.GridData.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle itemToggle = base.GetItemToggle();
			if (itemToggle == null)
			{
				return;
			}
			itemToggle.SetToggleState(state, false, false, bJumpToLastFrame);
		}

		// Token: 0x040247B0 RID: 149424
		[Nullable(2)]
		protected IPinballRoleSelectGridItemData GridData;
	}
}
