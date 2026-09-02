using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004720 RID: 18208
	[NullableContext(1)]
	[Nullable(0)]
	internal class GameCommandWithValidators<[Nullable(0)] T> : IGameCommand<T>, IGameCommandBase where T : ICommandType
	{
		// Token: 0x17008199 RID: 33177
		// (get) Token: 0x0602F4BD RID: 193725 RVA: 0x00B36ECD File Offset: 0x00B350CD
		// (set) Token: 0x0602F4BE RID: 193726 RVA: 0x00B36ED5 File Offset: 0x00B350D5
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<TCommandHandleParams<T>> Execute { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x1700819A RID: 33178
		// (get) Token: 0x0602F4BF RID: 193727 RVA: 0x00B36EDE File Offset: 0x00B350DE
		// (set) Token: 0x0602F4C0 RID: 193728 RVA: 0x00B36EE6 File Offset: 0x00B350E6
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<TCommandHandleParams<T>> Undo { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x1700819B RID: 33179
		// (get) Token: 0x0602F4C1 RID: 193729 RVA: 0x00B36EEF File Offset: 0x00B350EF
		// (set) Token: 0x0602F4C2 RID: 193730 RVA: 0x00B36EF7 File Offset: 0x00B350F7
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TCommandHandleParams<T> Params { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x0602F4C3 RID: 193731 RVA: 0x00B36F00 File Offset: 0x00B35100
		public void AddValidator(IValidator validator)
		{
			this.Validators.Add(validator);
		}

		// Token: 0x0602F4C4 RID: 193732 RVA: 0x00B36F0F File Offset: 0x00B3510F
		public void RemoveValidator(IValidator validator)
		{
			this.Validators.Remove(validator);
		}

		// Token: 0x0401AF10 RID: 110352
		public HashSet<IValidator> Validators = new HashSet<IValidator>();
	}
}
