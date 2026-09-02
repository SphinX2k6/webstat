using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A90 RID: 10896
public class ChildSpineView : UiPanelBase
{
	// Token: 0x06015CFC RID: 89340 RVA: 0x0060C158 File Offset: 0x0060A358
	[NullableContext(2)]
	public unsafe void PlaySpineAnimation(string spineName, bool isLoop = true)
	{
		if (spineName != null && spineName != string.Empty)
		{
			TArray<UUIItem> tarray = new TArray<UUIItem>();
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.GetAllAttachUIChildren(ref tarray);
			}
			TArray<UUIItem> tarray2 = tarray;
			for (int i = 0; i < tarray2.Num(); i++)
			{
				UUIItem uuiitem = tarray2.Get(i);
				if (uuiitem is UUISpineRenderable)
				{
					USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = uuiitem.GetOwner().GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) as USpineSkeletonAnimationComponent;
					if (uspineSkeletonAnimationComponent != null)
					{
						uspineSkeletonAnimationComponent.SetAnimation(0, spineName, isLoop);
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Loading;
						ELogAuthor author = ELogAuthor.CB;
						string message = "SpecialTransitionView 播放Spine动画";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("spineName", spineName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isLoop", isLoop);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
			}
		}
	}
}
