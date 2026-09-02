using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A56 RID: 19030
	public class UiSpineSkeletonLoadModule : UiResourceLoadModule
	{
		// Token: 0x06031B73 RID: 203635 RVA: 0x00C63E88 File Offset: 0x00C62088
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<USpineSkeletonDataAsset> LoadAtlasAssetAsync(string skeletonPath, USpineSkeletonAnimationComponent spine)
		{
			UiSpineSkeletonLoadModule.<LoadAtlasAssetAsync>d__0 <LoadAtlasAssetAsync>d__;
			<LoadAtlasAssetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<USpineSkeletonDataAsset>.Create();
			<LoadAtlasAssetAsync>d__.<>4__this = this;
			<LoadAtlasAssetAsync>d__.skeletonPath = skeletonPath;
			<LoadAtlasAssetAsync>d__.spine = spine;
			<LoadAtlasAssetAsync>d__.<>1__state = -1;
			<LoadAtlasAssetAsync>d__.<>t__builder.Start<UiSpineSkeletonLoadModule.<LoadAtlasAssetAsync>d__0>(ref <LoadAtlasAssetAsync>d__);
			return <LoadAtlasAssetAsync>d__.<>t__builder.Task;
		}
	}
}
