using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B98 RID: 23448
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class InteractionProcessor
	{
		// Token: 0x1700975E RID: 38750
		// (get) Token: 0x0603B4C3 RID: 242883 RVA: 0x00F03D0E File Offset: 0x00F01F0E
		// (set) Token: 0x0603B4C4 RID: 242884 RVA: 0x00F03D16 File Offset: 0x00F01F16
		private protected EInteractionType InteractionType { protected get; private set; }

		// Token: 0x1700975F RID: 38751
		// (get) Token: 0x0603B4C5 RID: 242885 RVA: 0x00F03D1F File Offset: 0x00F01F1F
		// (set) Token: 0x0603B4C6 RID: 242886 RVA: 0x00F03D27 File Offset: 0x00F01F27
		protected bool IsPressing { get; set; }

		// Token: 0x17009760 RID: 38752
		// (get) Token: 0x0603B4C7 RID: 242887 RVA: 0x00F03D30 File Offset: 0x00F01F30
		// (set) Token: 0x0603B4C8 RID: 242888 RVA: 0x00F03D38 File Offset: 0x00F01F38
		protected bool IsCompleteInternal { get; set; }

		// Token: 0x17009761 RID: 38753
		// (get) Token: 0x0603B4C9 RID: 242889 RVA: 0x00F03D41 File Offset: 0x00F01F41
		// (set) Token: 0x0603B4CA RID: 242890 RVA: 0x00F03D49 File Offset: 0x00F01F49
		private protected int Index { protected get; private set; }

		// Token: 0x17009762 RID: 38754
		// (get) Token: 0x0603B4CB RID: 242891 RVA: 0x00F03D52 File Offset: 0x00F01F52
		// (set) Token: 0x0603B4CC RID: 242892 RVA: 0x00F03D5A File Offset: 0x00F01F5A
		private protected Entity Entity { protected get; private set; }

		// Token: 0x17009763 RID: 38755
		// (get) Token: 0x0603B4CD RID: 242893 RVA: 0x00F03D63 File Offset: 0x00F01F63
		public bool IsLongPressing
		{
			get
			{
				return this.IsLongPressType && this.IsPressing;
			}
		}

		// Token: 0x17009764 RID: 38756
		// (get) Token: 0x0603B4CE RID: 242894 RVA: 0x00F03D75 File Offset: 0x00F01F75
		public bool IsLongPressType
		{
			get
			{
				return this.InteractionType == EInteractionType.LongPress;
			}
		}

		// Token: 0x0603B4CF RID: 242895 RVA: 0x00F03D80 File Offset: 0x00F01F80
		protected InteractionProcessor(Entity entity, int index, EInteractionType type)
		{
			this.InteractionType = type;
			this.Entity = entity;
			this.Index = index;
		}

		// Token: 0x0603B4D0 RID: 242896
		public abstract void OnPress();

		// Token: 0x0603B4D1 RID: 242897
		public abstract void OnRelease();

		// Token: 0x0603B4D2 RID: 242898
		public abstract void OnReset();

		// Token: 0x0603B4D3 RID: 242899 RVA: 0x00F03D9D File Offset: 0x00F01F9D
		public virtual void SetTriggerAction(EInputAction? action)
		{
		}

		// Token: 0x0603B4D4 RID: 242900 RVA: 0x00F03D9F File Offset: 0x00F01F9F
		public bool IsCompleted()
		{
			return this.IsCompleteInternal;
		}

		// Token: 0x0603B4D5 RID: 242901 RVA: 0x00F03DA7 File Offset: 0x00F01FA7
		public void Reset()
		{
			this.IsCompleteInternal = false;
			this.OnReset();
		}

		// Token: 0x0603B4D6 RID: 242902 RVA: 0x00F03DB6 File Offset: 0x00F01FB6
		[NullableContext(0)]
		public virtual UniTask<bool> LoadAsset()
		{
			return UniTask.FromResult<bool>(true);
		}

		// Token: 0x0603B4D7 RID: 242903 RVA: 0x00F03DBE File Offset: 0x00F01FBE
		protected void TriggerComplete()
		{
			this.IsCompleteInternal = true;
		}
	}
}
