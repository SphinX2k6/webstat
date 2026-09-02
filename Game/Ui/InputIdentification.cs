using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.Input.BattleInputData;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F2 RID: 18930
	[NullableContext(1)]
	[Nullable(0)]
	public class InputIdentification
	{
		// Token: 0x06031829 RID: 202793 RVA: 0x00C569A1 File Offset: 0x00C54BA1
		public InputIdentification(string name)
		{
			this.NameInternal = name;
		}

		// Token: 0x1700844A RID: 33866
		// (get) Token: 0x0603182A RID: 202794 RVA: 0x00C569C6 File Offset: 0x00C54BC6
		public string Name
		{
			get
			{
				return this.NameInternal;
			}
		}

		// Token: 0x0603182B RID: 202795 RVA: 0x00C569D0 File Offset: 0x00C54BD0
		[NullableContext(2)]
		public EInputAction? GetInputAction(BattleInputData inputData)
		{
			if (this.InputActionInternal != EInputAction.None)
			{
				return new EInputAction?(this.InputActionInternal);
			}
			if (inputData == null)
			{
				return null;
			}
			EInputAction? action = inputData.GetAction(this.NameInternal);
			if (action == null)
			{
				return null;
			}
			this.InputActionInternal = action.Value;
			return new EInputAction?(this.InputActionInternal);
		}

		// Token: 0x0603182C RID: 202796 RVA: 0x00C56A40 File Offset: 0x00C54C40
		[NullableContext(2)]
		public EInputAxis? GetInputAxis(BattleInputData inputData)
		{
			if (this.InputAxisInternal != EInputAxis.None)
			{
				return new EInputAxis?(this.InputAxisInternal);
			}
			if (inputData == null)
			{
				return null;
			}
			EInputAxis? axis = inputData.GetAxis(this.NameInternal);
			if (axis == null)
			{
				return null;
			}
			this.InputAxisInternal = axis.Value;
			return new EInputAxis?(this.InputAxisInternal);
		}

		// Token: 0x0401CCB7 RID: 117943
		private readonly string NameInternal;

		// Token: 0x0401CCB8 RID: 117944
		private EInputAction InputActionInternal = EInputAction.None;

		// Token: 0x0401CCB9 RID: 117945
		private EInputAxis InputAxisInternal = EInputAxis.None;
	}
}
