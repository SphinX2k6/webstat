using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057AC RID: 22444
	[NullableContext(1)]
	[Nullable(0)]
	public class EyeProtectItemData
	{
		// Token: 0x06039106 RID: 233734 RVA: 0x00E76554 File Offset: 0x00E74754
		public EyeProtectItemData(int modeValue, string modeName, EyeProtectViewModel viewModel)
		{
			this.ModeValue = modeValue;
			this.ModeName = modeName;
			this.ViewModel = viewModel;
		}

		// Token: 0x06039107 RID: 233735 RVA: 0x00E7657C File Offset: 0x00E7477C
		public int GetModeValue()
		{
			return this.ModeValue;
		}

		// Token: 0x06039108 RID: 233736 RVA: 0x00E76584 File Offset: 0x00E74784
		public string GetModeName()
		{
			return this.ModeName;
		}

		// Token: 0x06039109 RID: 233737 RVA: 0x00E7658C File Offset: 0x00E7478C
		public bool IsCustom()
		{
			return this.ModeValue == 2;
		}

		// Token: 0x0603910A RID: 233738 RVA: 0x00E76597 File Offset: 0x00E74797
		[NullableContext(2)]
		public EyeProtectViewModel GetViewModel()
		{
			return this.ViewModel;
		}

		// Token: 0x040207C1 RID: 133057
		protected bool IsActiveInternal;

		// Token: 0x040207C2 RID: 133058
		protected int ModeValue;

		// Token: 0x040207C3 RID: 133059
		protected string ModeName = "";

		// Token: 0x040207C4 RID: 133060
		[Nullable(2)]
		protected EyeProtectViewModel ViewModel;
	}
}
