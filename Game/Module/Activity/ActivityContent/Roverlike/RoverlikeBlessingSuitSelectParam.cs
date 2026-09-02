using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C0 RID: 25536
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeBlessingSuitSelectParam : IRoverlikeBlessingSuitSelectParam
	{
		// Token: 0x17009D97 RID: 40343
		// (get) Token: 0x0604020B RID: 262667 RVA: 0x0106FD56 File Offset: 0x0106DF56
		// (set) Token: 0x0604020C RID: 262668 RVA: 0x0106FD5E File Offset: 0x0106DF5E
		public List<IRoverlikeBlessingSuitData> SuitDataList { get; set; } = new List<IRoverlikeBlessingSuitData>();

		// Token: 0x17009D98 RID: 40344
		// (get) Token: 0x0604020D RID: 262669 RVA: 0x0106FD67 File Offset: 0x0106DF67
		// (set) Token: 0x0604020E RID: 262670 RVA: 0x0106FD6F File Offset: 0x0106DF6F
		public int SelectedIndex { get; set; }
	}
}
