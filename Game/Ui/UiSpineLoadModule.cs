using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A57 RID: 19031
	[NullableContext(1)]
	[Nullable(0)]
	public class UiSpineLoadModule
	{
		// Token: 0x06031B75 RID: 203637 RVA: 0x00C63EE4 File Offset: 0x00C620E4
		public UniTask LoadSpineAssetAsync(string atlasPath, string skeletonPath, USpineSkeletonAnimationComponent spine)
		{
			UiSpineLoadModule.<LoadSpineAssetAsync>d__2 <LoadSpineAssetAsync>d__;
			<LoadSpineAssetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadSpineAssetAsync>d__.<>4__this = this;
			<LoadSpineAssetAsync>d__.atlasPath = atlasPath;
			<LoadSpineAssetAsync>d__.skeletonPath = skeletonPath;
			<LoadSpineAssetAsync>d__.spine = spine;
			<LoadSpineAssetAsync>d__.<>1__state = -1;
			<LoadSpineAssetAsync>d__.<>t__builder.Start<UiSpineLoadModule.<LoadSpineAssetAsync>d__2>(ref <LoadSpineAssetAsync>d__);
			return <LoadSpineAssetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B76 RID: 203638 RVA: 0x00C63F3F File Offset: 0x00C6213F
		public void Clear()
		{
			this.AtlasModule.Clear();
			this.SkeletonModule.Clear();
		}

		// Token: 0x0401CEB4 RID: 118452
		private readonly UiSpineAtlasLoadModule AtlasModule = new UiSpineAtlasLoadModule();

		// Token: 0x0401CEB5 RID: 118453
		private readonly UiSpineSkeletonLoadModule SkeletonModule = new UiSpineSkeletonLoadModule();
	}
}
