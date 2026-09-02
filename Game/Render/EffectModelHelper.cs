using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200476C RID: 18284
	public class EffectModelHelper
	{
		// Token: 0x0602F720 RID: 194336 RVA: 0x00B47052 File Offset: 0x00B45252
		public static void VectorToRotator(FVector vector, FRotator rotator)
		{
			rotator.Pitch = vector.Y;
			rotator.Yaw = vector.Z;
			rotator.Roll = vector.X;
		}

		// Token: 0x0602F721 RID: 194337 RVA: 0x00B4707C File Offset: 0x00B4527C
		[NullableContext(2)]
		public unsafe static USceneComponent AddSceneComponent(AActor actor, [Nullable(1)] UClass componentClass, USceneComponent parent, FTransform? transform = null, bool bDeferredFinish = false, UEffectModelBase effectModel = null)
		{
			if (actor != null && componentClass != null)
			{
				USceneComponent usceneComponent;
				if (transform == null)
				{
					usceneComponent = UKuroEffectLibrary.AddSceneComponent(actor, componentClass.ClassStackOnlyPtr, parent, bDeferredFinish);
				}
				else
				{
					usceneComponent = UKuroEffectLibrary.AddSceneComponentWithTransform(actor, componentClass.ClassStackOnlyPtr, parent, bDeferredFinish, transform.Value);
				}
				if (usceneComponent == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "特效试图生成在不属于任何世界的actor上";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", actor);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentClass", componentClass);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EffectDataPath", effectModel);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				return usceneComponent;
			}
			return null;
		}
	}
}
