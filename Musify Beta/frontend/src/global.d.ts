declare namespace JSX {
    interface IntrinsicElements {
      'hls-video': React.DetailedHTMLProps<React.HTMLAttributes<HTMLElement>, HTMLElement> & {
        controls?: boolean; // Add other attributes here as needed
      };
    }
  }
  