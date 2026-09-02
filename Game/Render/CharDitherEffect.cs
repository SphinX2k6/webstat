using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004746 RID: 18246
	[NullableContext(1)]
	[Nullable(0)]
	public class CharDitherEffect : CharRenderBase
	{
		// Token: 0x0602F58F RID: 193935 RVA: 0x00B3B040 File Offset: 0x00B39240
		public override void Start()
		{
			if (this.RenderComponent.UseMaterialContainerV2)
			{
				this.MaterialContainerV2 = (this.RenderComponent.GetComponent(13) as CharMaterialContainerV2);
				this.MaterialContainer = null;
			}
			else
			{
				this.MaterialContainer = (this.RenderComponent.GetComponent(1) as CharMaterialContainer);
				this.MaterialContainerV2 = null;
			}
			if (this.MaterialContainer == null && this.MaterialContainerV2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.HCS, "非NPC类型没有添加组件 material container", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.CachedDitherRate = 1f;
			this.DitheringRate = 0f;
			this.DitherOutRangeA = -0.2f;
			this.DitherOutRangeB = 1f;
			this.DitherType = ECharacterDitherType.UnDefined;
			this.IsDithering = false;
			this.DitherTypeMap = new Dictionary<ECharacterDitherType, bool>();
			base.OnInitSuccess();
		}

		// Token: 0x0602F590 RID: 193936 RVA: 0x00B3B110 File Offset: 0x00B39310
		public override void OnResetRenderState()
		{
			this.SetDitherRate(1f);
			this.DitherType = ECharacterDitherType.UnDefined;
			this.IsDithering = false;
			this.DitherTypeMap.Clear();
		}

		// Token: 0x0602F591 RID: 193937 RVA: 0x00B3B136 File Offset: 0x00B39336
		public void UpdateNpcDitherComponent()
		{
		}

		// Token: 0x0602F592 RID: 193938 RVA: 0x00B3B138 File Offset: 0x00B39338
		public void SetDitherEffect(float ditherRate, ECharacterDitherType ditherType)
		{
			if (ditherRate == this.CachedDitherRate)
			{
				return;
			}
			if (ditherRate >= 0f && ditherRate < 1f)
			{
				this.DitherTypeMap[ditherType] = true;
				if (this.DitherType == ditherType || this.DitherType < ditherType)
				{
					this.DitherType = ditherType;
					if (!this.IsDithering)
					{
						this.EnableDitherEffect();
					}
					this.SetDitherRate(ditherRate);
					return;
				}
			}
			else
			{
				if (this.DitherTypeMap.ContainsKey(ditherType))
				{
					this.DitherTypeMap[ditherType] = false;
				}
				bool flag = false;
				ECharacterDitherType echaracterDitherType = ECharacterDitherType.UnDefined;
				foreach (KeyValuePair<ECharacterDitherType, bool> keyValuePair in this.DitherTypeMap)
				{
					bool value = keyValuePair.Value;
					ECharacterDitherType key = keyValuePair.Key;
					flag = (flag || value);
					if (value && echaracterDitherType < key)
					{
						echaracterDitherType = key;
					}
				}
				this.DitherType = echaracterDitherType;
				if (!flag && this.IsDithering)
				{
					this.RemoveDitherEffect();
				}
			}
		}

		// Token: 0x0602F593 RID: 193939 RVA: 0x00B3B240 File Offset: 0x00B39440
		public void SetDitherMask(List<EKuroCharMeshPart> mask, bool onlyDitherInMainPass)
		{
			this.DitherMask.Clear();
			this.DitherMask.AddRange(mask);
			this.OnlyDitherInMainPass = onlyDitherInMainPass;
			if (this.IsDithering)
			{
				this.DoRemoveDither();
				this.DoEnableDither();
				this.DoSetDitherParams(this.DitheringRate);
			}
		}

		// Token: 0x0602F594 RID: 193940 RVA: 0x00B3B280 File Offset: 0x00B39480
		public void RemoveDitherEffect()
		{
			this.DoRemoveDither();
			this.SetDitherRate(1f);
			this.IsDithering = false;
		}

		// Token: 0x0602F595 RID: 193941 RVA: 0x00B3B29A File Offset: 0x00B3949A
		public void TempRemoveDither()
		{
			if (this.IsDithering)
			{
				this.DoRemoveDither();
			}
		}

		// Token: 0x0602F596 RID: 193942 RVA: 0x00B3B2AA File Offset: 0x00B394AA
		public void TempRecoverDither()
		{
			if (this.IsDithering)
			{
				this.DoEnableDither();
			}
		}

		// Token: 0x0602F597 RID: 193943 RVA: 0x00B3B2BA File Offset: 0x00B394BA
		private void EnableDitherEffect()
		{
			this.DoEnableDither();
			this.IsDithering = true;
		}

		// Token: 0x0602F598 RID: 193944 RVA: 0x00B3B2C9 File Offset: 0x00B394C9
		public override void PreBodyInfoRuntimeInit(FName bodyName)
		{
			if (this.IsDithering)
			{
				this.DoRemoveDither();
			}
		}

		// Token: 0x0602F599 RID: 193945 RVA: 0x00B3B2D9 File Offset: 0x00B394D9
		public override void PostBodyInfoRuntimeInit(FName bodyName)
		{
			if (this.IsDithering)
			{
				this.DoEnableDither();
				this.DoSetDitherParams(this.DitheringRate);
			}
		}

		// Token: 0x0602F59A RID: 193946 RVA: 0x00B3B2F5 File Offset: 0x00B394F5
		public override void Update()
		{
		}

		// Token: 0x0602F59B RID: 193947 RVA: 0x00B3B2F7 File Offset: 0x00B394F7
		public override int GetComponentId()
		{
			return 3;
		}

		// Token: 0x0602F59C RID: 193948 RVA: 0x00B3B2FA File Offset: 0x00B394FA
		public float GetDitherRate()
		{
			return this.CachedDitherRate;
		}

		// Token: 0x0602F59D RID: 193949 RVA: 0x00B3B304 File Offset: 0x00B39504
		private void SetDitherRate(float ditherRate)
		{
			this.DitheringRate = Singleton<MathUtils>.Instance.RangeClamp(ditherRate, 0f, 1f, this.DitherOutRangeA, this.DitherOutRangeB);
			if ((double)Math.Abs(this.CachedDitherRate - ditherRate) < 1E-06)
			{
				return;
			}
			this.DoSetDitherParams(this.DitheringRate);
			this.CachedDitherRate = ditherRate;
		}

		// Token: 0x0602F59E RID: 193950 RVA: 0x00B3B368 File Offset: 0x00B39568
		private unsafe void DoEnableDither()
		{
			ECharacterRenderingType? renderType = base.GetRenderingComponent().RenderType;
			ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.Npc;
			if (!(renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "CharacterEnableDither";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "CharName";
				CharRenderingComponent renderingComponent = base.GetRenderingComponent();
				ptr = new ValueTuple<string, object>(item, (renderingComponent != null) ? renderingComponent.GetCachedOwnerName() : null);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item2 = "Entity";
				CharRenderingComponent renderingComponent2 = base.GetRenderingComponent();
				int? num;
				if (renderingComponent2 == null)
				{
					num = null;
				}
				else
				{
					Entity cachedOwnerEntity = renderingComponent2.GetCachedOwnerEntity();
					num = ((cachedOwnerEntity != null) ? new int?(cachedOwnerEntity.Id) : null);
				}
				ptr2 = new ValueTuple<string, object>(item2, num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Type", this.DitherType);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			if (this.MaterialContainerV2 != null)
			{
				this.MaterialContainerV2.AddAlphaTestCount(EKuroCharBodySpecifiedType.All);
				if (this.DitherMask.Count > 0)
				{
					using (List<EKuroCharMeshPart>.Enumerator enumerator = this.DitherMask.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							EKuroCharMeshPart value = enumerator.Current;
							this.MaterialContainerV2.SetFloatUpdateParamPermanent(RenderConfig.UseDitherEffect, 1f, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, new EKuroCharMeshPart?(value));
						}
						return;
					}
				}
				this.MaterialContainerV2.SetFloatUpdateParamPermanent(RenderConfig.UseDitherEffect, 1f, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				return;
			}
			if (this.MaterialContainer != null)
			{
				this.MaterialContainer.UseAlphaTestCommon();
				this.MaterialContainer.SetFloat(new FName?(RenderConfig.UseDitherEffect), 1f, ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType.All);
			}
		}

		// Token: 0x0602F59F RID: 193951 RVA: 0x00B3B52C File Offset: 0x00B3972C
		private void DoSetDitherParams(float value)
		{
			if (this.MaterialContainerV2 != null)
			{
				this.MaterialContainerV2.SetFloatUpdateParamPermanent(RenderConfig.DitherValue, this.OnlyDitherInMainPass ? 1.2f : value, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				this.MaterialContainerV2.SetFloatUpdateParamPermanent(RenderConfig.DitherValueMainPass, this.OnlyDitherInMainPass ? value : 1.2f, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				return;
			}
			if (this.MaterialContainer != null)
			{
				this.MaterialContainer.SetFloat(new FName?(RenderConfig.DitherValue), this.OnlyDitherInMainPass ? 1.2f : value, ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType.All);
				this.MaterialContainer.SetFloat(new FName?(RenderConfig.DitherValueMainPass), this.OnlyDitherInMainPass ? value : 1.2f, ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType.All);
			}
		}

		// Token: 0x0602F5A0 RID: 193952 RVA: 0x00B3B5F0 File Offset: 0x00B397F0
		private unsafe void DoRemoveDither()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "CharacterDisableDither";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CharName";
			CharRenderingComponent renderingComponent = base.GetRenderingComponent();
			ptr = new ValueTuple<string, object>(item, (renderingComponent != null) ? renderingComponent.GetCachedOwnerName() : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "Entity";
			CharRenderingComponent renderingComponent2 = base.GetRenderingComponent();
			int? num;
			if (renderingComponent2 == null)
			{
				num = null;
			}
			else
			{
				Entity cachedOwnerEntity = renderingComponent2.GetCachedOwnerEntity();
				num = ((cachedOwnerEntity != null) ? new int?(cachedOwnerEntity.Id) : null);
			}
			ptr2 = new ValueTuple<string, object>(item2, num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Type", this.DitherType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.MaterialContainerV2 != null)
			{
				this.MaterialContainerV2.RemoveFloatUpdateParamPermanent(RenderConfig.UseDitherEffect, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				this.MaterialContainerV2.RemoveFloatUpdateParamPermanent(RenderConfig.DitherValue, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				this.MaterialContainerV2.RemoveFloatUpdateParamPermanent(RenderConfig.DitherValueMainPass, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, null);
				this.MaterialContainerV2.RemoveAlphaTestCount(EKuroCharBodySpecifiedType.All);
				return;
			}
			if (this.MaterialContainer != null)
			{
				this.MaterialContainer.RevertAlphaTestCommon();
				this.MaterialContainer.SetFloat(new FName?(RenderConfig.UseDitherEffect), 0f, ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType.All);
			}
		}

		// Token: 0x0602F5A1 RID: 193953 RVA: 0x00B3B74F File Offset: 0x00B3994F
		public override string GetStatName()
		{
			return "CharDitherEffect";
		}

		// Token: 0x0401AF63 RID: 110435
		[Nullable(2)]
		public CharMaterialContainer MaterialContainer;

		// Token: 0x0401AF64 RID: 110436
		[Nullable(2)]
		public CharMaterialContainerV2 MaterialContainerV2;

		// Token: 0x0401AF65 RID: 110437
		private float DitheringRate = --0f;

		// Token: 0x0401AF66 RID: 110438
		private float DitherOutRangeA = --0f;

		// Token: 0x0401AF67 RID: 110439
		private float DitherOutRangeB = --0f;

		// Token: 0x0401AF68 RID: 110440
		private ECharacterDitherType DitherType;

		// Token: 0x0401AF69 RID: 110441
		private float CachedDitherRate = --0f;

		// Token: 0x0401AF6A RID: 110442
		private bool IsDithering;

		// Token: 0x0401AF6B RID: 110443
		[Nullable(2)]
		private Dictionary<ECharacterDitherType, bool> DitherTypeMap;

		// Token: 0x0401AF6C RID: 110444
		private bool OnlyDitherInMainPass;

		// Token: 0x0401AF6D RID: 110445
		private readonly List<EKuroCharMeshPart> DitherMask = new List<EKuroCharMeshPart>();
	}
}
