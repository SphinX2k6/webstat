using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x0200471B RID: 18203
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class Receiver<[Nullable(0)] T> : IReceiver<T> where T : ICommandType
	{
		// Token: 0x17008192 RID: 33170
		// (get) Token: 0x0602F4AD RID: 193709 RVA: 0x00B36EA3 File Offset: 0x00B350A3
		// (set) Token: 0x0602F4AE RID: 193710 RVA: 0x00B36EAB File Offset: 0x00B350AB
		[RequiredMember]
		public Action<TCommandHandleParams<T>> ReceiveExecute { get; set; }

		// Token: 0x17008193 RID: 33171
		// (get) Token: 0x0602F4AF RID: 193711 RVA: 0x00B36EB4 File Offset: 0x00B350B4
		// (set) Token: 0x0602F4B0 RID: 193712 RVA: 0x00B36EBC File Offset: 0x00B350BC
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<TCommandHandleParams<T>> ReceiveUndo { [return: Nullable(new byte[]
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

		// Token: 0x0602F4B1 RID: 193713 RVA: 0x00B36EC5 File Offset: 0x00B350C5
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public Receiver()
		{
		}
	}
}
