using System;

// Token: 0x020024DB RID: 9435
public class LongPressParam : ILongPressParam
{
	// Token: 0x17001754 RID: 5972
	// (get) Token: 0x060124FE RID: 75006 RVA: 0x005088E3 File Offset: 0x00506AE3
	// (set) Token: 0x060124FF RID: 75007 RVA: 0x005088EB File Offset: 0x00506AEB
	public float BeforeLongPressThreshold { get; set; }

	// Token: 0x17001755 RID: 5973
	// (get) Token: 0x06012500 RID: 75008 RVA: 0x005088F4 File Offset: 0x00506AF4
	// (set) Token: 0x06012501 RID: 75009 RVA: 0x005088FC File Offset: 0x00506AFC
	public float LongPressThreshold { get; set; }

	// Token: 0x17001756 RID: 5974
	// (get) Token: 0x06012502 RID: 75010 RVA: 0x00508905 File Offset: 0x00506B05
	// (set) Token: 0x06012503 RID: 75011 RVA: 0x0050890D File Offset: 0x00506B0D
	public float InvalidMoveDistance { get; set; }

	// Token: 0x17001757 RID: 5975
	// (get) Token: 0x06012504 RID: 75012 RVA: 0x00508916 File Offset: 0x00506B16
	// (set) Token: 0x06012505 RID: 75013 RVA: 0x0050891E File Offset: 0x00506B1E
	public float OffsetX { get; set; }

	// Token: 0x17001758 RID: 5976
	// (get) Token: 0x06012506 RID: 75014 RVA: 0x00508927 File Offset: 0x00506B27
	// (set) Token: 0x06012507 RID: 75015 RVA: 0x0050892F File Offset: 0x00506B2F
	public float OffsetY { get; set; }
}
