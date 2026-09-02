using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002FAF RID: 12207
public class GameplayCueMaterial : GameplayCueMagnitude
{
	// Token: 0x06018E46 RID: 101958 RVA: 0x0070CEEB File Offset: 0x0070B0EB
	protected override void OnInit()
	{
		base.OnInit();
		this.Resource = null;
	}

	// Token: 0x06018E47 RID: 101959 RVA: 0x0070CEFA File Offset: 0x0070B0FA
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
	}

	// Token: 0x06018E48 RID: 101960 RVA: 0x0070CF03 File Offset: 0x0070B103
	protected override void OnCreate()
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(base.GetPath(), delegate([Nullable(2)] UObject res, string _)
		{
			if (!this.IsActive)
			{
				return;
			}
			Action beginCallback = this.BeginCallback;
			if (beginCallback != null)
			{
				beginCallback();
			}
			this.Resource = res;
			this.AddMaterial();
			this.AddFinishCallback();
			base.OnCreate();
		}, 100, "js_undefined");
	}

	// Token: 0x06018E49 RID: 101961 RVA: 0x0070CF29 File Offset: 0x0070B129
	protected override void OnDestroy()
	{
		this.Resource = null;
		base.OnDestroy();
		this.RemoveMaterialController();
		this.OnMaterialEnd(this.MaterialId);
	}

	// Token: 0x06018E4A RID: 101962 RVA: 0x0070CF4C File Offset: 0x0070B14C
	private void RemoveMaterialController()
	{
		if (this.MaterialId < 0)
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = base.GetCharRenderingComponent();
		if (charRenderingComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "RemoveMaterialController CharRenderingComponent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.CueConfig.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.MaterialId = -1;
			return;
		}
		charRenderingComponent.SetEffectPause(this.MaterialId, false);
		EMaterial materialType = this.MaterialType;
		if (materialType != EMaterial.Data)
		{
			if (materialType == EMaterial.DataGroup)
			{
				charRenderingComponent.RemoveMaterialControllerDataGroupWithEnding(this.MaterialId);
			}
		}
		else
		{
			charRenderingComponent.RemoveMaterialControllerDataWithEnding(this.MaterialId);
		}
		this.MaterialId = -1;
	}

	// Token: 0x06018E4B RID: 101963 RVA: 0x0070CFEA File Offset: 0x0070B1EA
	protected override void OnSetMagnitude(float normalizedValue)
	{
		base.GetCharRenderingComponent().SetEffectProgress(normalizedValue, this.MaterialId);
	}

	// Token: 0x06018E4C RID: 101964 RVA: 0x0070CFFE File Offset: 0x0070B1FE
	[NullableContext(1)]
	public override void OnChangeRole(EntityHandle newEntityHandle)
	{
		this.InChangeRole = true;
		if (this.Resource != null && this.MaterialId != -1)
		{
			this.RemoveMaterialController();
		}
		this.InChangeRole = false;
		base.OnChangeRole(newEntityHandle);
		this.AddMaterial();
	}

	// Token: 0x06018E4D RID: 101965 RVA: 0x0070D034 File Offset: 0x0070B234
	private unsafe void AddMaterial()
	{
		if (!this.ActorInternal.IsValid() || this.Resource == null)
		{
			return;
		}
		UObject resource = this.Resource;
		CharRenderingComponent charRenderingComponent = base.GetCharRenderingComponent();
		switch (GameplayCueController.GetMaterialType(resource))
		{
		case EMaterial.Other:
		{
			this.MaterialType = EMaterial.Other;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "附加材质类型错误:";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff特效Id", this.CueConfig.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("材质路径", this.CueConfig.Path);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			break;
		}
		case EMaterial.Data:
			this.MaterialType = EMaterial.Data;
			this.MaterialId = charRenderingComponent.AddMaterialControllerData(resource);
			break;
		case EMaterial.DataGroup:
			this.MaterialType = EMaterial.DataGroup;
			this.MaterialId = charRenderingComponent.AddMaterialControllerDataGroup(resource);
			break;
		}
		if (this.MaterialId >= 0 && this.UseMagnitude())
		{
			charRenderingComponent.SetEffectPause(this.MaterialId, true);
		}
	}

	// Token: 0x06018E4E RID: 101966 RVA: 0x0070D144 File Offset: 0x0070B344
	private void AddFinishCallback()
	{
		if (this.EndCallback != null && !this.IsInstant)
		{
			EMaterial materialType = this.MaterialType;
			if (materialType == EMaterial.Data)
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.GetCharRenderingComponent(), EEventName.OnRemoveMaterialController, new Action<int>(this.OnMaterialEnd));
				return;
			}
			if (materialType != EMaterial.DataGroup)
			{
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.GetCharRenderingComponent(), EEventName.OnRemoveMaterialControllerGroup, new Action<int>(this.OnMaterialEnd));
		}
	}

	// Token: 0x06018E4F RID: 101967 RVA: 0x0070D1B8 File Offset: 0x0070B3B8
	private void RemoveFinishCallback()
	{
		EMaterial materialType = this.MaterialType;
		if (materialType != EMaterial.Data)
		{
			if (materialType != EMaterial.DataGroup)
			{
				return;
			}
			CharRenderingComponent charRenderingComponent = base.GetCharRenderingComponent();
			if (Singleton<EventSystem>.Instance.HasWithTarget<int>(charRenderingComponent, EEventName.OnRemoveMaterialControllerGroup, new Action<int>(this.OnMaterialEnd)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int>(charRenderingComponent, EEventName.OnRemoveMaterialControllerGroup, new Action<int>(this.OnMaterialEnd));
			}
		}
		else
		{
			CharRenderingComponent charRenderingComponent2 = base.GetCharRenderingComponent();
			if (Singleton<EventSystem>.Instance.HasWithTarget<int>(charRenderingComponent2, EEventName.OnRemoveMaterialController, new Action<int>(this.OnMaterialEnd)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int>(charRenderingComponent2, EEventName.OnRemoveMaterialController, new Action<int>(this.OnMaterialEnd));
				return;
			}
		}
	}

	// Token: 0x06018E50 RID: 101968 RVA: 0x0070D25A File Offset: 0x0070B45A
	private void OnMaterialEnd(int mId)
	{
		if (mId == this.MaterialId && this.EndCallback != null && !this.InChangeRole)
		{
			this.RemoveFinishCallback();
			Action endCallback = this.EndCallback;
			this.EndCallback = null;
			endCallback();
		}
	}

	// Token: 0x0400C282 RID: 49794
	private int MaterialId = -1;

	// Token: 0x0400C283 RID: 49795
	private EMaterial MaterialType;

	// Token: 0x0400C284 RID: 49796
	[Nullable(2)]
	private UObject Resource;

	// Token: 0x0400C285 RID: 49797
	private bool InChangeRole;
}
