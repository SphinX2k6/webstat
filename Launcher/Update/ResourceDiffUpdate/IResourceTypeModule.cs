using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D5 RID: 17621
	[NullableContext(1)]
	public interface IResourceTypeModule
	{
		// Token: 0x0602E7BC RID: 190396
		[NullableContext(0)]
		UniTask<bool> PrepareManifests();

		// Token: 0x0602E7BD RID: 190397
		PackClassification ClassifyPacks(ResourceSelectionContext context, bool forceMax = false);

		// Token: 0x0602E7BE RID: 190398
		long GetLocalSize(IReadOnlyList<string> pakNames);

		// Token: 0x0602E7BF RID: 190399
		void Delete(IReadOnlyList<string> pakNames);
	}
}
