using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D3 RID: 17619
	[NullableContext(1)]
	[Nullable(0)]
	public class OptionalPackSelector
	{
		// Token: 0x0602E7B8 RID: 190392 RVA: 0x00B01A90 File Offset: 0x00AFFC90
		public static SelectionDecision Select(IReadOnlyList<IResourceTypeModule> modules, ResourceSelectionContext context)
		{
			List<ResPackageInfo> list = new List<ResPackageInfo>();
			List<ResPackageInfo> list2 = new List<ResPackageInfo>();
			long num = 0L;
			long num2 = 0L;
			foreach (IResourceTypeModule resourceTypeModule in modules)
			{
				PackClassification packClassification = resourceTypeModule.ClassifyPacks(context, false);
				list.AddRange(packClassification.MinPacks);
				list2.AddRange(packClassification.MaxPacks);
				num += packClassification.MinSize;
				num2 += packClassification.MaxSize;
			}
			return new SelectionDecision
			{
				MinSize = num,
				MaxSize = num2,
				MinPacks = list,
				MaxPacks = list2
			};
		}

		// Token: 0x0602E7B9 RID: 190393 RVA: 0x00B01B40 File Offset: 0x00AFFD40
		public static SelectionDecision SelectMax(IReadOnlyList<IResourceTypeModule> modules, ResourceSelectionContext context)
		{
			List<ResPackageInfo> list = new List<ResPackageInfo>();
			long num = 0L;
			foreach (IResourceTypeModule resourceTypeModule in modules)
			{
				PackClassification packClassification = resourceTypeModule.ClassifyPacks(context, true);
				list.AddRange(packClassification.MaxPacks);
				num += packClassification.MaxSize;
			}
			return new SelectionDecision
			{
				MinSize = num,
				MaxSize = num,
				MinPacks = list,
				MaxPacks = list
			};
		}
	}
}
