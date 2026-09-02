using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DF9 RID: 24057
	public class MaterialSelectionCacheData : IStaticVariableResetter
	{
		// Token: 0x0603C86B RID: 247915 RVA: 0x00F5F56A File Offset: 0x00F5D76A
		public static void SetMaterialSelectIndex(int index)
		{
			MaterialSelectionCacheData.TmpIndex = index;
		}

		// Token: 0x0603C86C RID: 247916 RVA: 0x00F5F572 File Offset: 0x00F5D772
		public static int GetMaterialSelectIndex()
		{
			return MaterialSelectionCacheData.TmpIndex;
		}

		// Token: 0x0603C86D RID: 247917 RVA: 0x00F5F579 File Offset: 0x00F5D779
		public static void SetMaterialUseNum(int num)
		{
			MaterialSelectionCacheData.TmpNum = num;
		}

		// Token: 0x0603C86E RID: 247918 RVA: 0x00F5F581 File Offset: 0x00F5D781
		public static int GetMaterialUseNum()
		{
			return MaterialSelectionCacheData.TmpNum;
		}

		// Token: 0x0603C86F RID: 247919 RVA: 0x00F5F588 File Offset: 0x00F5D788
		public static bool CheckCanSelected(int itemId)
		{
			return ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemId, 0) >= MaterialSelectionCacheData.GetMaterialUseNum();
		}

		// Token: 0x0603C870 RID: 247920 RVA: 0x00F5F5A0 File Offset: 0x00F5D7A0
		static MaterialSelectionCacheData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MaterialSelectionCacheData.CreateStaticDefaultValue), new Action(MaterialSelectionCacheData.ResetStaticDefaultValue));
		}

		// Token: 0x0603C871 RID: 247921 RVA: 0x00F5F5BF File Offset: 0x00F5D7BF
		public static void CreateStaticDefaultValue()
		{
			MaterialSelectionCacheData.TmpSelectedMaterialData = null;
			MaterialSelectionCacheData.MaterialTypeNum = 0;
			MaterialSelectionCacheData.TmpIndex = 0;
			MaterialSelectionCacheData.TmpNum = 0;
		}

		// Token: 0x0603C872 RID: 247922 RVA: 0x00F5F5D9 File Offset: 0x00F5D7D9
		public static void ResetStaticDefaultValue()
		{
			MaterialSelectionCacheData.TmpSelectedMaterialData = null;
			MaterialSelectionCacheData.MaterialTypeNum = 0;
			MaterialSelectionCacheData.TmpIndex = 0;
			MaterialSelectionCacheData.TmpNum = 0;
		}

		// Token: 0x04022088 RID: 139400
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static List<ISelectedData> TmpSelectedMaterialData;

		// Token: 0x04022089 RID: 139401
		public static int MaterialTypeNum;

		// Token: 0x0402208A RID: 139402
		private static int TmpIndex;

		// Token: 0x0402208B RID: 139403
		private static int TmpNum;
	}
}
