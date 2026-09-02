using System;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BAA RID: 23466
	public class InteractNavigation
	{
		// Token: 0x0603B5E7 RID: 243175 RVA: 0x00F09D20 File Offset: 0x00F07F20
		public unsafe InteractNavigation(float lookUpThreshold, float zoomThreshold, bool allowLoop)
		{
			if (lookUpThreshold < 0f || zoomThreshold < 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.ZJC;
				string message = "设置lookUp阈值和zoomThreshold阈值错误!";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("lookUpThreshold", lookUpThreshold);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("zoomThreshold", zoomThreshold);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.LookUpThreshold = lookUpThreshold;
			this.ZoomThreshold = zoomThreshold;
			this.AllowLoop = allowLoop;
		}

		// Token: 0x1700976F RID: 38767
		// (get) Token: 0x0603B5E8 RID: 243176 RVA: 0x00F09DB7 File Offset: 0x00F07FB7
		// (set) Token: 0x0603B5E9 RID: 243177 RVA: 0x00F09DBF File Offset: 0x00F07FBF
		public int Index
		{
			get
			{
				return this.IndexInternal;
			}
			set
			{
				this.IndexInternal = value;
			}
		}

		// Token: 0x17009770 RID: 38768
		// (get) Token: 0x0603B5EA RID: 243178 RVA: 0x00F09DC8 File Offset: 0x00F07FC8
		public int TotalNum
		{
			get
			{
				return this.TotalNumInternal;
			}
		}

		// Token: 0x0603B5EB RID: 243179 RVA: 0x00F09DD0 File Offset: 0x00F07FD0
		public bool UpdateValue(EInputAxis axisType, float value, int? totalNum = null)
		{
			int indexInternal = this.IndexInternal;
			if (this.IndexInternal != 0)
			{
				if (axisType == EInputAxis.LookUp)
				{
					if (this.LookUpValue * value < 0f)
					{
						this.LookUpValue = 0f;
					}
					this.LookUpValue += value;
					if (Math.Abs(this.LookUpValue) >= this.LookUpThreshold)
					{
						int num = ((value > 0f) ? 1 : -1) * (int)Math.Floor((double)Math.Abs(this.LookUpValue / this.LookUpThreshold));
						this.LookUpValue -= this.LookUpThreshold * (float)num;
						this.IndexInternal += num;
					}
				}
				else if (axisType == EInputAxis.Zoom)
				{
					float num2 = -value;
					if (this.ZoomValue * num2 < 0f)
					{
						this.ZoomValue = 0f;
					}
					this.ZoomValue += num2;
					if (Math.Abs(this.ZoomValue) >= this.ZoomThreshold)
					{
						int num3 = ((num2 > 0f) ? 1 : -1) * (int)Math.Floor((double)Math.Abs(this.ZoomValue / this.ZoomThreshold));
						this.ZoomValue -= this.ZoomThreshold * (float)num3;
						this.IndexInternal += num3;
					}
				}
			}
			else
			{
				this.IndexInternal = 0;
			}
			this.UpdateIndexInternal(totalNum);
			return this.IndexInternal != indexInternal;
		}

		// Token: 0x0603B5EC RID: 243180 RVA: 0x00F09F44 File Offset: 0x00F08144
		public bool UpdateIndex(int totalNum)
		{
			int indexInternal = this.IndexInternal;
			this.UpdateIndexInternal(new int?(totalNum));
			return this.IndexInternal != indexInternal;
		}

		// Token: 0x0603B5ED RID: 243181 RVA: 0x00F09F70 File Offset: 0x00F08170
		private void UpdateIndexInternal(int? totalNum)
		{
			if (totalNum != null)
			{
				this.TotalNumInternal = totalNum.Value;
			}
			if (this.TotalNumInternal == 0)
			{
				return;
			}
			if (this.IndexInternal < 0 || this.IndexInternal >= this.TotalNumInternal)
			{
				if (!this.AllowLoop)
				{
					this.IndexInternal = Math.Max(0, Math.Min(this.IndexInternal, this.TotalNumInternal - 1));
					return;
				}
				this.IndexInternal %= this.TotalNumInternal;
				if (this.IndexInternal < 0)
				{
					this.IndexInternal = this.TotalNumInternal + this.IndexInternal;
				}
			}
		}

		// Token: 0x04021757 RID: 137047
		private int TotalNumInternal;

		// Token: 0x04021758 RID: 137048
		private int IndexInternal;

		// Token: 0x04021759 RID: 137049
		private float LookUpValue;

		// Token: 0x0402175A RID: 137050
		private float ZoomValue;

		// Token: 0x0402175B RID: 137051
		private readonly float LookUpThreshold;

		// Token: 0x0402175C RID: 137052
		private readonly float ZoomThreshold;

		// Token: 0x0402175D RID: 137053
		private readonly bool AllowLoop;
	}
}
