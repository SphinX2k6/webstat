using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02002C82 RID: 11394
public class UiModelDataComponent : UiModelComponentBase
{
	// Token: 0x06016DB1 RID: 93617 RVA: 0x0065759A File Offset: 0x0065579A
	public EUiModelLoadState GetModelLoadState()
	{
		return this.ModelLoadStateInternal;
	}

	// Token: 0x06016DB2 RID: 93618 RVA: 0x006575A2 File Offset: 0x006557A2
	public void SetModelLoadState(EUiModelLoadState state)
	{
		this.ModelLoadStateInternal = state;
		if (state == EUiModelLoadState.IsLoading)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart);
			return;
		}
		if (state == EUiModelLoadState.LoadComplete)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Owner, EEventName.OnUiModelLoadComplete);
		}
	}

	// Token: 0x06016DB3 RID: 93619 RVA: 0x006575E0 File Offset: 0x006557E0
	public bool GetVisible()
	{
		return this.Visible;
	}

	// Token: 0x06016DB4 RID: 93620 RVA: 0x006575E8 File Offset: 0x006557E8
	public bool? GetLoadingVisible()
	{
		return this.LoadingVisible;
	}

	// Token: 0x06016DB5 RID: 93621 RVA: 0x006575F0 File Offset: 0x006557F0
	public void ClearLoadingVisible()
	{
		this.LoadingVisible = null;
	}

	// Token: 0x06016DB6 RID: 93622 RVA: 0x00657600 File Offset: 0x00655800
	public unsafe bool SetVisible(bool visible)
	{
		if (this.ModelLoadStateInternal == EUiModelLoadState.IsLoading)
		{
			this.LoadingVisible = new bool?(visible);
			return true;
		}
		if (this.Visible == visible)
		{
			return false;
		}
		this.Visible = visible;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiComponent;
		ELogAuthor author = ELogAuthor.BB;
		string message = "设置Ui模型显隐";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ModelUseWay", base.Owner.UseWay);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Visible", visible);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		base.Owner.OnVisibleChange(visible);
		return true;
	}

	// Token: 0x06016DB7 RID: 93623 RVA: 0x006576AA File Offset: 0x006558AA
	public float GetDitherEffectValue()
	{
		return this.DitherEffectValue;
	}

	// Token: 0x06016DB8 RID: 93624 RVA: 0x006576B2 File Offset: 0x006558B2
	public void SetDitherEffect(float value)
	{
		this.DitherEffectValue = value;
		base.Owner.OnSetDitherEffect(value);
	}

	// Token: 0x06016DB9 RID: 93625 RVA: 0x006576C7 File Offset: 0x006558C7
	public bool GetLoadingIconFollowState()
	{
		return this.LoadingIconFollowActor;
	}

	// Token: 0x06016DBA RID: 93626 RVA: 0x006576CF File Offset: 0x006558CF
	public void SetLoadingIconFollowState(bool state)
	{
		this.LoadingIconFollowActor = state;
	}

	// Token: 0x0400B045 RID: 45125
	public int ModelConfigId;

	// Token: 0x0400B046 RID: 45126
	public EUiModelActorType? ModelActorType;

	// Token: 0x0400B047 RID: 45127
	public EUiModelUseWay? ModelUseWay;

	// Token: 0x0400B048 RID: 45128
	public EUiModelType? ModelType;

	// Token: 0x0400B049 RID: 45129
	private EUiModelLoadState ModelLoadStateInternal;

	// Token: 0x0400B04A RID: 45130
	private bool Visible;

	// Token: 0x0400B04B RID: 45131
	private bool? LoadingVisible;

	// Token: 0x0400B04C RID: 45132
	private float DitherEffectValue = 1f;

	// Token: 0x0400B04D RID: 45133
	private bool LoadingIconFollowActor;
}
