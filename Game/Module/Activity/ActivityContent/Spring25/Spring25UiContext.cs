using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x0200635F RID: 25439
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25UiContext
	{
		// Token: 0x17009CCC RID: 40140
		// (get) Token: 0x0603FDEA RID: 261610 RVA: 0x0106234D File Offset: 0x0106054D
		// (set) Token: 0x0603FDEB RID: 261611 RVA: 0x01062355 File Offset: 0x01060555
		public int? CurrentSignId
		{
			get
			{
				return this.CurrentSignIdInternal;
			}
			set
			{
				this.CurrentSignIdInternal = value;
			}
		}

		// Token: 0x17009CCD RID: 40141
		// (get) Token: 0x0603FDEC RID: 261612 RVA: 0x01062360 File Offset: 0x01060560
		// (set) Token: 0x0603FDED RID: 261613 RVA: 0x0106239F File Offset: 0x0106059F
		public int? CurrentLetterSignId
		{
			get
			{
				if (this.CurrentLetterSignIdInternal == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Spring25, ELogAuthor.WZ, "打开面板之前，未能获得TaskId，请确认Letter TaskId 是否已赋值", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return this.CurrentLetterSignIdInternal;
			}
			set
			{
				this.CurrentLetterSignIdInternal = value;
				if (value != null)
				{
					this.AttachedModel.SetLetterClickedBySignId(value.Value, true);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.Spring25SelectLetter, value.Value);
				}
			}
		}

		// Token: 0x0603FDEE RID: 261614 RVA: 0x010623DB File Offset: 0x010605DB
		public Spring25UiContext(Spring25Model model)
		{
			this.AttachedModel = model;
		}

		// Token: 0x0603FDEF RID: 261615 RVA: 0x010623EA File Offset: 0x010605EA
		public void Dispose()
		{
			this.CurrentSignIdInternal = null;
		}

		// Token: 0x04023E66 RID: 147046
		private readonly Spring25Model AttachedModel;

		// Token: 0x04023E67 RID: 147047
		private int? CurrentSignIdInternal;

		// Token: 0x04023E68 RID: 147048
		private int? CurrentLetterSignIdInternal;
	}
}
