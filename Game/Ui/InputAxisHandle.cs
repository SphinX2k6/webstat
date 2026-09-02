using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049ED RID: 18925
	[NullableContext(1)]
	[Nullable(0)]
	public class InputAxisHandle : InputDistributeHandle<float>
	{
		// Token: 0x060317DF RID: 202719 RVA: 0x00C55B4E File Offset: 0x00C53D4E
		public InputAxisHandle(string inputDistributeTag, string name) : base(inputDistributeTag, name)
		{
		}

		// Token: 0x060317E0 RID: 202720 RVA: 0x00C55B58 File Offset: 0x00C53D58
		public void BindAxis(TInputHandle<float> axisCallback)
		{
			base.Bind(axisCallback);
		}

		// Token: 0x060317E1 RID: 202721 RVA: 0x00C55B61 File Offset: 0x00C53D61
		public void UnBindAxis(TInputHandle<float> axisCallback)
		{
			base.UnBind(axisCallback);
		}

		// Token: 0x060317E2 RID: 202722 RVA: 0x00C55B6A File Offset: 0x00C53D6A
		public void BindAxisIgnoreLimit(TInputHandle<float> axisCallback)
		{
			base.BindIgnoreLimit(axisCallback);
		}

		// Token: 0x060317E3 RID: 202723 RVA: 0x00C55B73 File Offset: 0x00C53D73
		public void UnBindAxisIgnoreLimit(TInputHandle<float> axisCallback)
		{
			base.UnBindIgnoreLimit(axisCallback);
		}

		// Token: 0x060317E4 RID: 202724 RVA: 0x00C55B7C File Offset: 0x00C53D7C
		public void InputAxis(float value)
		{
			this.InputCacheAxisValue(value);
			base.Call(value);
		}

		// Token: 0x060317E5 RID: 202725 RVA: 0x00C55B8C File Offset: 0x00C53D8C
		public void InputAxisIgnoreLimit(float value)
		{
			this.InputCacheAxisValueIgnoreLimit(value);
			base.CallIgnoreLimit(value);
		}

		// Token: 0x060317E6 RID: 202726 RVA: 0x00C55B9C File Offset: 0x00C53D9C
		public void InputCacheAxisValue(float value)
		{
			this.CacheAxisValue = value;
		}

		// Token: 0x060317E7 RID: 202727 RVA: 0x00C55BA5 File Offset: 0x00C53DA5
		public void InputCacheAxisValueIgnoreLimit(float value)
		{
			this.CacheAxisValueIgnoreLimit = value;
		}

		// Token: 0x060317E8 RID: 202728 RVA: 0x00C55BAE File Offset: 0x00C53DAE
		public float GetCacheAxisValue()
		{
			return this.CacheAxisValue;
		}

		// Token: 0x060317E9 RID: 202729 RVA: 0x00C55BB6 File Offset: 0x00C53DB6
		public float GetCacheAxisValueIgnoreLimit()
		{
			return this.CacheAxisValueIgnoreLimit;
		}

		// Token: 0x0401CCAD RID: 117933
		private float CacheAxisValue;

		// Token: 0x0401CCAE RID: 117934
		private float CacheAxisValueIgnoreLimit;
	}
}
