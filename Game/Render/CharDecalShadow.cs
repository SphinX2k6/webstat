using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.DecalShadow;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004745 RID: 18245
	[NullableContext(1)]
	[Nullable(0)]
	public class CharDecalShadow : CharRenderBase, IStaticVariableResetter
	{
		// Token: 0x0602F578 RID: 193912 RVA: 0x00B3A804 File Offset: 0x00B38A04
		public static void OnSetDecalShadowEnabled(int enable)
		{
			if (enable > 0)
			{
				using (HashSet<CharDecalShadow>.Enumerator enumerator = CharDecalShadow.ComponentsSet.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CharDecalShadow charDecalShadow = enumerator.Current;
						charDecalShadow.EnableDecalShadow();
					}
					return;
				}
			}
			foreach (CharDecalShadow charDecalShadow2 in CharDecalShadow.ComponentsSet)
			{
				charDecalShadow2.DisableDecalShadow();
			}
		}

		// Token: 0x0602F579 RID: 193913 RVA: 0x00B3A898 File Offset: 0x00B38A98
		public override void Start()
		{
			this.CachedOwner = base.GetRenderingComponent().GetOwner();
			this.Config = base.GetRenderingComponent().DecalShadowConfig;
			if (this.Config == null)
			{
				this.Config = Singleton<RenderDataManager>.Instance.GetGlobalDecalShadowConfig();
			}
			if (this.Config == null)
			{
				return;
			}
			this.CollectPrimitives();
			CharDecalShadow.ComponentsSet.Add(this);
			if (!CharDecalShadow.GlobalEventRegistered)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.SetDecalShadowEnabled;
				Action<int> handle;
				if ((handle = CharDecalShadow.<>O.<0>__OnSetDecalShadowEnabled) == null)
				{
					handle = (CharDecalShadow.<>O.<0>__OnSetDecalShadowEnabled = new Action<int>(CharDecalShadow.OnSetDecalShadowEnabled));
				}
				instance.Add(name, handle);
				CharDecalShadow.GlobalEventRegistered = true;
			}
			base.OnInitSuccess();
		}

		// Token: 0x0602F57A RID: 193914 RVA: 0x00B3A938 File Offset: 0x00B38B38
		public override void Destroy()
		{
			AActor decalShadowActor = this.DecalShadowActor;
			if (decalShadowActor != null)
			{
				decalShadowActor.K2_DestroyActor();
			}
			CharDecalShadow.ComponentsSet.Remove(this);
		}

		// Token: 0x0602F57B RID: 193915 RVA: 0x00B3A958 File Offset: 0x00B38B58
		private void CollectPrimitives()
		{
			TArray<UActorComponent> tarray = this.CachedOwner.K2_GetComponentsByClass(UPrimitiveComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				UPrimitiveComponent uprimitiveComponent = tarray.Get(i) as UPrimitiveComponent;
				if (uprimitiveComponent != null && uprimitiveComponent.CastShadow)
				{
					this.PrimitiveComponents[uprimitiveComponent.GetName()] = uprimitiveComponent;
				}
			}
		}

		// Token: 0x0602F57C RID: 193916 RVA: 0x00B3A9B8 File Offset: 0x00B38BB8
		public void AddPrimitiveComponent(string name, UPrimitiveComponent comp)
		{
			if (!comp.CastShadow)
			{
				return;
			}
			this.RemovePrimitiveComponent(name);
			this.PrimitiveComponents[name] = comp;
			if (!this.RealTimeShadowEnabled)
			{
				comp.CastShadow = false;
			}
		}

		// Token: 0x0602F57D RID: 193917 RVA: 0x00B3A9E8 File Offset: 0x00B38BE8
		public void RemovePrimitiveComponent(string name)
		{
			UPrimitiveComponent uprimitiveComponent;
			if (this.PrimitiveComponents.TryGetValue(name, out uprimitiveComponent))
			{
				uprimitiveComponent.CastShadow = true;
				this.PrimitiveComponents.Remove(name);
			}
		}

		// Token: 0x0602F57E RID: 193918 RVA: 0x00B3AA19 File Offset: 0x00B38C19
		public void EnableDecalShadow()
		{
			if (this.DecalShadowEnabled)
			{
				return;
			}
			if (this.Config == null)
			{
				return;
			}
			this.DecalShadowEnabled = true;
			if (this.ShouldCastShadow)
			{
				this.UpdateDecalShadow(true);
			}
		}

		// Token: 0x0602F57F RID: 193919 RVA: 0x00B3AA43 File Offset: 0x00B38C43
		public void DisableDecalShadow()
		{
			if (!this.DecalShadowEnabled)
			{
				return;
			}
			this.DecalShadowEnabled = false;
			if (this.ShouldCastShadow)
			{
				this.UpdateDecalShadow(false);
			}
		}

		// Token: 0x0602F580 RID: 193920 RVA: 0x00B3AA64 File Offset: 0x00B38C64
		public void UpdateDecalShadow(bool visible)
		{
			if (visible)
			{
				PDA_DecalShadowConfig_C config = this.Config;
				if (config == null)
				{
					return;
				}
				AActor cachedOwner = this.CachedOwner;
				UCapsuleComponent ucapsuleComponent = cachedOwner.GetComponentByClass(UCapsuleComponent.StaticClass()) as UCapsuleComponent;
				if (ucapsuleComponent == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "Decal Shadow找不到胶囊体";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor: ", cachedOwner);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (this.DecalShadowActor == null)
				{
					this.DecalShadowActor = Singleton<ActorSystem>.Instance.Spawn(AActor.StaticClass(), new FTransformDouble(), this.CachedOwner);
					AActor decalShadowActor = this.DecalShadowActor;
					TSubclassOf<UActorComponent> @class = UDecalComponent.StaticClass();
					bool bManualAttachment = false;
					FTransform ftransform = new FTransform();
					this.DecalShadowComponent = (decalShadowActor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UDecalComponent);
					ControllerBase<AttachToActorController>.Instance.AttachToActor(this.DecalShadowActor, this.CachedOwner, EDetachType.DestroyExternal, "CharDecalShadow.EnableDecalShadow", null, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true, false, false, false);
					AActor decalShadowActor2 = this.DecalShadowActor;
					FVector fvector = new FVector(0f, -90f, 0f);
					decalShadowActor2.K2_SetActorRotation(FRotator.MakeFromEuler(fvector), true);
					FHitResult fhitResult = new FHitResult();
					this.DecalShadowActor.D_K2_SetActorRelativeLocation(new FVectorDouble(0.0, 0.0, (double)(-(double)ucapsuleComponent.CapsuleHalfHeight)), false, ref fhitResult, true);
					this.SetDecalShadowConfig(config, ucapsuleComponent.CapsuleRadius, ucapsuleComponent.CapsuleHalfHeight);
				}
				else
				{
					this.DecalShadowComponent.SetVisibility(true, false);
					if (!Singleton<Info>.Instance.IsGameRunning())
					{
						this.SetDecalShadowConfig(config, ucapsuleComponent.CapsuleRadius, ucapsuleComponent.CapsuleHalfHeight);
					}
				}
			}
			else
			{
				UDecalComponent decalShadowComponent = this.DecalShadowComponent;
				if (decalShadowComponent != null)
				{
					decalShadowComponent.SetVisibility(false, false);
				}
			}
			this.SetDecalShadowOpacity(this.ShadowOpacity);
		}

		// Token: 0x0602F581 RID: 193921 RVA: 0x00B3AC1A File Offset: 0x00B38E1A
		public void EnableRealTimeShadow()
		{
			if (this.RealTimeShadowEnabled)
			{
				return;
			}
			this.RealTimeShadowEnabled = true;
			if (this.ShouldCastShadow)
			{
				this.UpdateRealTimeShadow(true);
			}
		}

		// Token: 0x0602F582 RID: 193922 RVA: 0x00B3AC3B File Offset: 0x00B38E3B
		public void DisableRealTimeShadow()
		{
			if (!this.RealTimeShadowEnabled)
			{
				return;
			}
			this.RealTimeShadowEnabled = false;
			if (this.ShouldCastShadow)
			{
				this.UpdateRealTimeShadow(false);
			}
		}

		// Token: 0x0602F583 RID: 193923 RVA: 0x00B3AC5C File Offset: 0x00B38E5C
		public void UpdateRealTimeShadow(bool visible)
		{
			if (visible)
			{
				foreach (UPrimitiveComponent uprimitiveComponent in this.PrimitiveComponents.Values)
				{
					uprimitiveComponent.SetCastShadow(true);
					uprimitiveComponent.ForceCastShadowInRayTracing = true;
				}
				CharBodyEffect charBodyEffect = base.GetRenderingComponent().GetComponent(9) as CharBodyEffect;
				if (charBodyEffect != null)
				{
					charBodyEffect.SetCastShadow(true);
				}
			}
			else
			{
				foreach (UPrimitiveComponent uprimitiveComponent2 in this.PrimitiveComponents.Values)
				{
					uprimitiveComponent2.SetCastShadow(false);
					uprimitiveComponent2.ForceCastShadowInRayTracing = false;
				}
				CharBodyEffect charBodyEffect2 = base.GetRenderingComponent().GetComponent(9) as CharBodyEffect;
				if (charBodyEffect2 != null)
				{
					charBodyEffect2.SetCastShadow(false);
				}
			}
			this.SetRealTimeShadowOpacity(this.ShadowOpacity);
		}

		// Token: 0x0602F584 RID: 193924 RVA: 0x00B3AD50 File Offset: 0x00B38F50
		public void DisableAllShadow()
		{
			this.DisableDecalShadow();
			this.DisableRealTimeShadow();
		}

		// Token: 0x0602F585 RID: 193925 RVA: 0x00B3AD60 File Offset: 0x00B38F60
		public unsafe void SetShouldCastShadow(bool castShadow)
		{
			if (castShadow == this.ShouldCastShadow)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "CharDecalShadow SetShouldCastShadow";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("castShadow", castShadow);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "name";
			CharRenderingComponent renderingComponent = base.GetRenderingComponent();
			ptr = new ValueTuple<string, object>(item, (renderingComponent != null) ? renderingComponent.GetCachedOwnerName() : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ShouldCastShadow = castShadow;
			if (castShadow)
			{
				this.UpdateDecalShadow(this.DecalShadowEnabled);
				this.UpdateRealTimeShadow(this.RealTimeShadowEnabled);
				return;
			}
			this.UpdateDecalShadow(false);
			this.UpdateRealTimeShadow(false);
		}

		// Token: 0x0602F586 RID: 193926 RVA: 0x00B3AE14 File Offset: 0x00B39014
		public void SetDecalShadowOpacity(float opacity)
		{
			this.ShadowOpacity = opacity;
			if (this.DecalShadowComponent == null)
			{
				return;
			}
			if (this.DecalShadowEnabled && this.ShouldCastShadow)
			{
				if ((double)opacity < 0.0001)
				{
					this.DecalShadowComponent.SetVisibility(false, false);
					return;
				}
				this.DecalShadowComponent.SetVisibility(true, false);
				this.DynamicDecalShadowMaterial.SetScalarParameterValue(new FName("Opacity"), opacity);
			}
		}

		// Token: 0x0602F587 RID: 193927 RVA: 0x00B3AE80 File Offset: 0x00B39080
		public void SetRealTimeShadowOpacity(float opacity)
		{
			this.ShadowOpacity = opacity;
			if (this.RealTimeShadowEnabled)
			{
				ECharacterRenderingType? renderType = base.GetRenderingComponent().RenderType;
				ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.Npc;
				if ((renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null) && this.ShouldCastShadow)
				{
					bool flag = opacity > CharDecalShadow.OpacityThresholdToDisableShadow;
					foreach (UPrimitiveComponent uprimitiveComponent in this.PrimitiveComponents.Values)
					{
						uprimitiveComponent.SetCastShadow(flag);
						uprimitiveComponent.ForceCastShadowInRayTracing = flag;
					}
				}
			}
		}

		// Token: 0x0602F588 RID: 193928 RVA: 0x00B3AF20 File Offset: 0x00B39120
		private void SetDecalShadowConfig(PDA_DecalShadowConfig_C config, float capsuleRadius, float capsuleHalfHeight)
		{
			if (this.DecalShadowComponent == null)
			{
				return;
			}
			this.DecalShadowComponent.ZFadingFactor = config.ZDistanceFadeFactor;
			this.DecalShadowComponent.ZFadingPower = config.ZDistanceFadePower;
			this.DynamicDecalShadowMaterial = UKismetMaterialLibrary.CreateDynamicMaterialInstance(this.DecalShadowComponent, config.DecalShadowMaterial, default(FName), EMIDCreationFlags.None);
			this.DecalShadowComponent.SetDecalMaterial(this.DynamicDecalShadowMaterial);
			double num = 25.0 * (double)config.DecalBoxScaleHori;
			float num2 = capsuleHalfHeight * config.DecalBoxScaleVerti;
			this.DecalShadowComponent.D_SetWorldScale3D(new FVectorDouble((double)num2, num, num));
		}

		// Token: 0x0602F589 RID: 193929 RVA: 0x00B3AFB9 File Offset: 0x00B391B9
		public override string GetStatName()
		{
			return "CharDecalShadow";
		}

		// Token: 0x0602F58A RID: 193930 RVA: 0x00B3AFC0 File Offset: 0x00B391C0
		public override int GetComponentId()
		{
			return 10;
		}

		// Token: 0x0602F58B RID: 193931 RVA: 0x00B3AFC4 File Offset: 0x00B391C4
		static CharDecalShadow()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CharDecalShadow.CreateStaticDefaultValue), new Action(CharDecalShadow.ResetStaticDefaultValue));
		}

		// Token: 0x0602F58C RID: 193932 RVA: 0x00B3AFF3 File Offset: 0x00B391F3
		public static void CreateStaticDefaultValue()
		{
			CharDecalShadow.ComponentsSet = new HashSet<CharDecalShadow>();
			CharDecalShadow.GlobalEventRegistered = false;
		}

		// Token: 0x0602F58D RID: 193933 RVA: 0x00B3B005 File Offset: 0x00B39205
		public static void ResetStaticDefaultValue()
		{
			CharDecalShadow.ComponentsSet = null;
			CharDecalShadow.GlobalEventRegistered = false;
		}

		// Token: 0x0401AF56 RID: 110422
		private static bool GlobalEventRegistered = false;

		// Token: 0x0401AF57 RID: 110423
		private static HashSet<CharDecalShadow> ComponentsSet;

		// Token: 0x0401AF58 RID: 110424
		private bool ShouldCastShadow = true;

		// Token: 0x0401AF59 RID: 110425
		private bool DecalShadowEnabled;

		// Token: 0x0401AF5A RID: 110426
		private bool RealTimeShadowEnabled = true;

		// Token: 0x0401AF5B RID: 110427
		[Nullable(2)]
		private AActor CachedOwner;

		// Token: 0x0401AF5C RID: 110428
		[Nullable(2)]
		private PDA_DecalShadowConfig_C Config;

		// Token: 0x0401AF5D RID: 110429
		private readonly Dictionary<string, UPrimitiveComponent> PrimitiveComponents = new Dictionary<string, UPrimitiveComponent>();

		// Token: 0x0401AF5E RID: 110430
		[Nullable(2)]
		private AActor DecalShadowActor;

		// Token: 0x0401AF5F RID: 110431
		[Nullable(2)]
		private UDecalComponent DecalShadowComponent;

		// Token: 0x0401AF60 RID: 110432
		[Nullable(2)]
		private UMaterialInstanceDynamic DynamicDecalShadowMaterial;

		// Token: 0x0401AF61 RID: 110433
		private float ShadowOpacity = 1f;

		// Token: 0x0401AF62 RID: 110434
		private static readonly float OpacityThresholdToDisableShadow = 0.2f;

		// Token: 0x0200A87F RID: 43135
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040344B9 RID: 214201
			[Nullable(0)]
			public static Action<int> <0>__OnSetDecalShadowEnabled;
		}
	}
}
