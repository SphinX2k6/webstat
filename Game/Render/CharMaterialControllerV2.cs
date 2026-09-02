using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200474D RID: 18253
	[NullableContext(1)]
	[Nullable(0)]
	public class CharMaterialControllerV2 : CharRenderBase
	{
		// Token: 0x0602F5EA RID: 194026 RVA: 0x00B3C88A File Offset: 0x00B3AA8A
		public override string GetStatName()
		{
			return "CharMaterialControllerV2";
		}

		// Token: 0x0602F5EB RID: 194027 RVA: 0x00B3C891 File Offset: 0x00B3AA91
		public override void Start()
		{
			this.MaterialContainer = (base.GetRenderingComponent().GetComponent(13) as CharMaterialContainerV2);
			this.MaterialContainer.AddEffectFinishCallback(new Action<int>(this.OnEffectFinished));
			base.OnInitSuccess();
		}

		// Token: 0x0602F5EC RID: 194028 RVA: 0x00B3C8C8 File Offset: 0x00B3AAC8
		public int GetEffectCount()
		{
			return this.EffectsAdded.Count;
		}

		// Token: 0x0602F5ED RID: 194029 RVA: 0x00B3C8D5 File Offset: 0x00B3AAD5
		public bool GetRuntimeMaterialControllerValid(int handle)
		{
			return this.EffectsAdded.ContainsKey(handle);
		}

		// Token: 0x0602F5EE RID: 194030 RVA: 0x00B3C8E3 File Offset: 0x00B3AAE3
		public void SetEffectProgress(float progress, int handle)
		{
			if (this.EffectsAdded.ContainsKey(handle))
			{
				CharMaterialContainerV2 materialContainer = this.MaterialContainer;
				if (materialContainer == null)
				{
					return;
				}
				materialContainer.SetEffectProgress(handle, progress);
			}
		}

		// Token: 0x0602F5EF RID: 194031 RVA: 0x00B3C908 File Offset: 0x00B3AB08
		[NullableContext(2)]
		public unsafe int AddMaterialControllerData([Nullable(1)] PD_CharacterControllerData_C data, UObject userData = null, USkeletalMeshComponent animObject = null)
		{
			Stat.CreateNoFlameGraph("CharMaterialControllerV2_AddData_" + data.GetName(), "", "");
			CharRenderingComponent renderingComponent = base.GetRenderingComponent();
			ECharacterRenderingType? echaracterRenderingType = (renderingComponent != null) ? renderingComponent.GetRenderType() : null;
			if (data.OnlyApplyOnLocalPlayer)
			{
				ECharacterRenderingType? echaracterRenderingType2 = echaracterRenderingType;
				ECharacterRenderingType echaracterRenderingType3 = ECharacterRenderingType.LocalPlayer;
				if (!(echaracterRenderingType2.GetValueOrDefault() == echaracterRenderingType3 & echaracterRenderingType2 != null))
				{
					return -1;
				}
			}
			if (data.NeverApplyOnLocalPlayer)
			{
				ECharacterRenderingType? echaracterRenderingType2 = echaracterRenderingType;
				ECharacterRenderingType echaracterRenderingType3 = ECharacterRenderingType.LocalPlayer;
				if (echaracterRenderingType2.GetValueOrDefault() == echaracterRenderingType3 & echaracterRenderingType2 != null)
				{
					return -1;
				}
			}
			CharMaterialControllerHandle charMaterialControllerHandle = new CharMaterialControllerHandle();
			bool needLoop = data.DataType == ECharacterControllerType.Runtime;
			bool paused = data.DataType == ECharacterControllerType.Manual;
			bool hiddenAfterEffect = data.HiddenAfterEffect;
			int num = this.MaterialContainer.AddEffect(data, needLoop, paused, animObject, hiddenAfterEffect);
			if (num < 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "添加材质控制器失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IdentifyName", this.MaterialContainer.IdentifyName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AssetData", data);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return num;
			}
			charMaterialControllerHandle.HandleId = num;
			charMaterialControllerHandle.UserData = userData;
			charMaterialControllerHandle.AssetData = data;
			this.EffectsAdded[num] = charMaterialControllerHandle;
			if (data.ForceBattleMask)
			{
				this.ForceMaskEffects.Add(num);
				this.MaterialContainer.AddBattleMaskCount(EKuroCharBodySpecifiedType.All);
			}
			if (data.ForceUpdateOnAdd)
			{
				this.MaterialContainer.UpdateEffectsOnly();
			}
			return num;
		}

		// Token: 0x0602F5F0 RID: 194032 RVA: 0x00B3CAA0 File Offset: 0x00B3ACA0
		public bool RemoveMaterialControllerData(int handle)
		{
			CharMaterialControllerHandle charMaterialControllerHandle;
			if (this.EffectsAdded.TryGetValue(handle, out charMaterialControllerHandle))
			{
				CharMaterialContainerV2 materialContainer = this.MaterialContainer;
				if (materialContainer != null)
				{
					materialContainer.RemoveEffect(handle);
				}
				return true;
			}
			return false;
		}

		// Token: 0x0602F5F1 RID: 194033 RVA: 0x00B3CAD4 File Offset: 0x00B3ACD4
		public bool RemoveMaterialControllerDataWithEnding(int handle)
		{
			CharMaterialControllerHandle charMaterialControllerHandle;
			if (this.EffectsAdded.TryGetValue(handle, out charMaterialControllerHandle))
			{
				CharMaterialContainerV2 materialContainer = this.MaterialContainer;
				if (materialContainer != null)
				{
					materialContainer.SetEffectLoop(handle, false);
				}
				CharMaterialContainerV2 materialContainer2 = this.MaterialContainer;
				if (materialContainer2 != null)
				{
					materialContainer2.SetEffectPause(handle, false);
				}
				return true;
			}
			return false;
		}

		// Token: 0x0602F5F2 RID: 194034 RVA: 0x00B3CB1C File Offset: 0x00B3AD1C
		public override void OnResetRenderState()
		{
			foreach (int num in this.EffectsAdded.Keys)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<int>(this, EEventName.OnRemoveMaterialController, num);
				this.RenderComponent.OnRemoveMaterialController(num);
			}
			this.EffectsAdded.Clear();
			int count = this.ForceMaskEffects.Count;
			for (int i = 0; i < count; i++)
			{
				this.MaterialContainer.RemoveBattleMaskCount(EKuroCharBodySpecifiedType.All);
			}
			this.ForceMaskEffects.Clear();
		}

		// Token: 0x0602F5F3 RID: 194035 RVA: 0x00B3CBC8 File Offset: 0x00B3ADC8
		public void CleanOriginEffectByOtherData()
		{
			foreach (KeyValuePair<int, CharMaterialControllerHandle> keyValuePair in this.EffectsAdded)
			{
				CharMaterialControllerHandle value = keyValuePair.Value;
				if (value.AssetData == null || !value.AssetData.NeverBeCleanedByOthers)
				{
					this.RemoveMaterialControllerData(value.HandleId);
				}
			}
		}

		// Token: 0x0602F5F4 RID: 194036 RVA: 0x00B3CC40 File Offset: 0x00B3AE40
		private void OnEffectFinished(int handle)
		{
			CharMaterialControllerHandle charMaterialControllerHandle;
			if (this.EffectsAdded.TryGetValue(handle, out charMaterialControllerHandle))
			{
				this.EffectsAdded.Remove(handle);
				Singleton<EventSystem>.Instance.EmitWithTarget<int>(this.RenderComponent, EEventName.OnRemoveMaterialController, handle);
				this.RenderComponent.OnRemoveMaterialController(handle);
				if (this.ForceMaskEffects.Contains(handle))
				{
					this.MaterialContainer.RemoveBattleMaskCount(EKuroCharBodySpecifiedType.All);
					this.ForceMaskEffects.Remove(handle);
				}
			}
		}

		// Token: 0x0602F5F5 RID: 194037 RVA: 0x00B3CCB4 File Offset: 0x00B3AEB4
		public override void Update()
		{
		}

		// Token: 0x0602F5F6 RID: 194038 RVA: 0x00B3CCB6 File Offset: 0x00B3AEB6
		public override void LateUpdate()
		{
		}

		// Token: 0x0602F5F7 RID: 194039 RVA: 0x00B3CCB8 File Offset: 0x00B3AEB8
		public override void Destroy()
		{
		}

		// Token: 0x0602F5F8 RID: 194040 RVA: 0x00B3CCBA File Offset: 0x00B3AEBA
		public override int GetComponentId()
		{
			return 14;
		}

		// Token: 0x0401AF89 RID: 110473
		[Nullable(2)]
		private CharMaterialContainerV2 MaterialContainer;

		// Token: 0x0401AF8A RID: 110474
		private readonly Dictionary<int, CharMaterialControllerHandle> EffectsAdded = new Dictionary<int, CharMaterialControllerHandle>();

		// Token: 0x0401AF8B RID: 110475
		private readonly HashSet<int> ForceMaskEffects = new HashSet<int>();
	}
}
